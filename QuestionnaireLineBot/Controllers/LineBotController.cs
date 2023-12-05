using Microsoft.AspNetCore.Mvc;
using QuestionnaireLineBot.Dtos.Profile;
using QuestionnaireLineBot.Dtos.Webhook;
using QuestionnaireLineBot.Enum;
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
        private readonly IAccountService _accountService;

        public LineBotController(LineBotService lineBotService, IAccountService accountService)
        {
            _lineBotService = lineBotService;
            _accountService = accountService;
        }

        [HttpPost("Webhook")]
        //[LineVerifySignature]
        public async Task<IActionResult> WebhookAsync(WebhookRequestBodyDto body)
        {
            await _lineBotService.ReceiveWebhook(body);
            
            return Ok();
        }
    }
}
