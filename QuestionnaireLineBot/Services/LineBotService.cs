using QuestionnaireLineBot.Dtos.Message;
using QuestionnaireLineBot.Dtos.Message.Request;
using QuestionnaireLineBot.Dtos.Webhook;
using QuestionnaireLineBot.Enum;
using QuestionnaireLineBot.Models;
using QuestionnaireLineBot.Providers;
using System.Net.Http.Headers;
using System.Text;
using QuestionnaireLineBot.Dtos.Profile;
using Microsoft.EntityFrameworkCore;

namespace QuestionnaireLineBot.Services
{
    public class LineBotService
    {
        private readonly IConfiguration _config;
        private readonly IAccountService _accountService;
        private readonly IQuestionsService _questionsService;
        private readonly LineBotQuestionnaireDbContext _lineBotQuestionnaireDbContext;
        private readonly string replyMessageUri = "https://api.line.me/v2/bot/message/reply";
        private readonly string broadcastMessageUri = "https://api.line.me/v2/bot/message/broadcast";
        private readonly IHttpClientFactory _httpClientFactory = null!;
        private readonly JsonProvider _jsonProvider = new JsonProvider();

        public LineBotService(IConfiguration config, IAccountService accountService, LineBotQuestionnaireDbContext lineBotQuestionnaireDbContext, IQuestionsService questionsService,
            IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _accountService = accountService;
            _lineBotQuestionnaireDbContext = lineBotQuestionnaireDbContext;
            _questionsService = questionsService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserProfileDto> GetUserProfile(string userId)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["LineBot:AccessToken"]);

                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.line.me/v2/bot/profile/{userId}"),
                };
                var response = await client.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();
                var profile = _jsonProvider.Deserialize<UserProfileDto>(content);
                return profile;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return new UserProfileDto();
            }
        }

        public async Task ReceiveWebhook(WebhookRequestBodyDto requestBody)
        {
            foreach (var eventObject in requestBody.Events)
            {
                switch (eventObject.Type)
                {
                    case WebhookEventTypeEnum.Message:
                        string text = eventObject.Message.Text;
                        if (text.Contains("問卷"))
                        {
                            string flexBubbleTemplate = File.ReadAllText(".\\Templates\\FlexBubbleTemplate.json");
                            var messageRequest = _jsonProvider.Deserialize<ReplyMessageRequestDto<FlexMessageDto<FlexBubbleContainerDto>>>(flexBubbleTemplate);
                            messageRequest.ReplyToken = eventObject.ReplyToken;


                            List<Question> questionBanks = new List<Question>() {
                                new Question()
                                {
                                    QuestionId = 1,
                                    ActivityId = "3b54fabe-55f5-4022-82bf-39e7fce65363",
                                    QuestionContent = "陽光是最佳的防腐劑，陽光法案包括「公職人員財產申報法」及「公職人員利益衝突迴避法」，宜蘭縣政府政風處將陽光法案列為重要推動工作項目，請問近3年（108~110年）展現之宣導成效為何？",
                                    Answer = 4
                                }
                            };
                            List<Option> options = new List<Option>() {
                                new Option()
                                {
                                    QuestionId = 1,
                                    OptionOrder = 1,
                                    OptionContent = "財產申報義務人網路申報比例連續3年達100％，完成「全面普及網路申報」之目標。"
                                },
                                new Option()
                                {
                                    QuestionId = 1,
                                    OptionOrder = 2,
                                    OptionContent = "財產申報義務人財產資料授權查調比例連續3年平均99.13％，完成「積極輔導財產授權」之目標。"
                                },
                                new Option()
                                {
                                    QuestionId = 1,
                                    OptionOrder = 3,
                                    OptionContent = "利益衝突迴避之自行迴避，彙整本府暨所屬各機關團體情形連續3年成長，足現「宣導作為大處著眼小處著手」之目標。"
                                },
                                new Option()
                                {
                                    QuestionId = 1,
                                    OptionOrder = 4,
                                    OptionContent = "以上皆是"
                                }
                            };

                            ReplyMessage(messageRequest);

                        }
                        else
                        {
                            var messages = new List<TextMessageDto>()
                            {
                                new TextMessageDto() {Text = "請點選問卷調查或輸入問卷調查" }
                            };
                            var messageRequest = new ReplyMessageRequestDto<TextMessageDto>()
                            {
                                ReplyToken = eventObject.ReplyToken,
                                Messages = messages
                            };
                            ReplyMessage(messageRequest);
                        }

                        break;
                    case WebhookEventTypeEnum.Postback:
                        string postbackData = eventObject.Postback.Data;
                        Console.WriteLine(postbackData);
                        break;

                    case WebhookEventTypeEnum.Follow:
                        var profile = await GetUserProfile(eventObject.Source.UserId);
                        await _accountService.PostAccount(profile);
                        break;
                }

            }
        }


        public async void ReplyMessage<T>(ReplyMessageRequestDto<T> request)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["LineBot:AccessToken"]);
                var json = _jsonProvider.Serialize(request);
                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(replyMessageUri),
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(requestMessage);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        // 負責處理收到的廣播訊息類行為合併正確反序列化
        public void BroadcastMessageHandler(string messageType, object requestBody)
        {
            string strBody = requestBody.ToString();
            switch (messageType)
            {
                case MessageTypeEnum.Text:
                    var messageRequest = _jsonProvider.Deserialize<BroadcastMessageRequestDto<TextMessageDto>>(strBody);
                    BroadcastMessage(messageRequest);
                    break;
            }

        }

        // 負責廣播訊息
        public async void BroadcastMessage<T>(BroadcastMessageRequestDto<T> request)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["LineBot:AccessToken"]);
                var json = _jsonProvider.Serialize(request);
                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(broadcastMessageUri),
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(requestMessage);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

    }
}