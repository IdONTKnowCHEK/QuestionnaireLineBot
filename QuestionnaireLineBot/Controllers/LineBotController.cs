﻿using Microsoft.AspNetCore.Mvc;
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
        [LineVerifySignature]
        public IActionResult Webhook(WebhookRequestBodyDto body)
        {
            _lineBotService.ReceiveWebhook(body);
            return Ok();
        }

        // GET: api/<LineBotController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LineBotController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LineBotController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LineBotController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LineBotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}