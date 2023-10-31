using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionnaireLineBot.Models;
using QuestionnaireLineBot.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuestionnaireLineBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly IQuestionsService _QuestionsService;
        private readonly LineBotService _LineBotService;


        public QuestionController(IQuestionsService QuestionsService, LineBotService LineBotService)
        {
            //_questionnaireDbContext = questionnaireDbContex;
            _QuestionsService = QuestionsService;
            _LineBotService = LineBotService;
        }

        // GET: api/<QuestionnaireController>
        [HttpGet]
        public async Task<ActionResult<List<Questions>>> Get()
        {
            var question = await _QuestionsService.GetAsync();
            return question;
        }

        // GET api/<QuestionnaireController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuestionnaireController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuestionnaireController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionnaireController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
