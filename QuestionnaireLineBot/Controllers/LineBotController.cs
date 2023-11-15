using Microsoft.AspNetCore.Mvc;
using QuestionnaireLineBot.Dtos.Webhook;
using QuestionnaireLineBot.Filter;
using QuestionnaireLineBot.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuestionnaireLineBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineBotController : ControllerBase
    {

        private readonly LineBotService _lineBotService;
        public LineBotController(LineBotService lineBotService) { 
            _lineBotService = lineBotService;
        }

        [HttpPost("Webhook")]
        //[LineVerifySignature]
        public IActionResult Webhook(WebhookRequestBodyDto body)
        {
            _lineBotService.ReceiveWebhook(body);
            return Ok();
        }
    }
}
