using QuestionnaireLineBot.Dtos.Message;
using QuestionnaireLineBot.Dtos.Message.Request;
using QuestionnaireLineBot.Dtos.Webhook;
using QuestionnaireLineBot.Enum;
using QuestionnaireLineBot.Models;
using QuestionnaireLineBot.Providers;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;

namespace QuestionnaireLineBot.Services
{
    public class LineBotService
    {
        private readonly IConfiguration _config;
        private readonly string replyMessageUri = "https://api.line.me/v2/bot/message/reply";
        private readonly string broadcastMessageUri = "https://api.line.me/v2/bot/message/broadcast";
        private static HttpClient client = new HttpClient();
        private readonly JsonProvider _jsonProvider = new JsonProvider();

        public LineBotService(IConfiguration config)
        {
            _config = config;
        }


        public void ReceiveWebhook(WebhookRequestBodyDto requestBody)
        {

        }


        public void ReplyMessageHandler<T>(string messageType, ReplyMessageRequestDto<T> requestBody)
        {
            ReplyMessage(requestBody);
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
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
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