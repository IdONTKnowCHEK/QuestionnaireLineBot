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

        // GET: api/<QuestionnaireController>/Questions
        [HttpGet]
        [Route("Questions")]
        public async Task<ActionResult<List<Question>>> GetQuestions()
        {
            var questions = await _QuestionsService.GetQuestions();
            return questions;
        }
        // GET: api/<QuestionnaireController>/Options
        [HttpGet]
        [Route("Options")]
        public async Task<ActionResult<List<Option>>> GetOptions()
        {
            var options = await _QuestionsService.GetOptions();
            return options;
        }
        // GET: api/<QuestionnaireController>/Activities
        [HttpGet]
        [Route("Activities")]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var activities = await _QuestionsService.GetActivities();
            return activities;
        }
    }
}
