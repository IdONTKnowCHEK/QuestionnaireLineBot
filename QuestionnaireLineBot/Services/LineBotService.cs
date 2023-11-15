using QuestionnaireLineBot.Dtos.Message;
using QuestionnaireLineBot.Dtos.Message.Request;
using QuestionnaireLineBot.Dtos.Webhook;
using QuestionnaireLineBot.Enum;
using QuestionnaireLineBot.Models;
using QuestionnaireLineBot.Providers;
using System.Net.Http.Headers;
using System.Text;
using QuestionnaireLineBot.Dtos.Profile;


namespace QuestionnaireLineBot.Services
{
    public class LineBotService
    {
        private readonly IConfiguration _config;
        //private readonly AccountService _accountService;
        private readonly string replyMessageUri = "https://api.line.me/v2/bot/message/reply";
        private readonly string broadcastMessageUri = "https://api.line.me/v2/bot/message/broadcast";
        private static HttpClient client = new HttpClient();
        private readonly JsonProvider _jsonProvider = new JsonProvider();

        public LineBotService(IConfiguration config)
        {
            _config = config;
            // _accountService = accountService;
        }

        public async Task<UserProfileDto> GetUserProfile(string userId)
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

        public async void ReceiveWebhook(WebhookRequestBodyDto requestBody)
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

                    case WebhookEventTypeEnum.Follow:
                        UserProfileDto profile = await GetUserProfile(eventObject.Source.UserId);
                        //_accountService.PostAccount(profile);
                        Console.WriteLine(profile.displayName);
                        break;
                }

            }
        }

        public async void ReplyMessage<T>(ReplyMessageRequestDto<T> request)
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

        // 負責推播訊息
        public async void BroadcastMessage<T>(BroadcastMessageRequestDto<T> request)
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

    }
}