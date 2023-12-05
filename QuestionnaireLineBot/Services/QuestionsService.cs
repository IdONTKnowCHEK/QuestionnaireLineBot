using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuestionnaireLineBot.Models;
using System.Collections.Generic;
using System.Linq;


namespace QuestionnaireLineBot.Services
{
    public interface IQuestionsService
    {
        Task<ActionResult<List<Question>>> GetQuestions();
        Task<ActionResult<List<Option>>> GetOptions();
        Task<ActionResult<List<Activity>>> GetActivities();
    }

    public class QuestionsService : IQuestionsService
    {
        private readonly LineBotQuestionnaireDbContext _lineBotQuestionnaireDbContext;


        public QuestionsService(LineBotQuestionnaireDbContext lineBotQuestionnaireDbContext)
        {
            _lineBotQuestionnaireDbContext = lineBotQuestionnaireDbContext;
        }

        public async Task<ActionResult<List<Question>>> GetQuestions()
        {
            try
            {
                return await _lineBotQuestionnaireDbContext.Questions.Include(q => q.Options).ToListAsync();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<ActionResult<List<Option>>> GetOptions()
        {
            try
            {
                return await _lineBotQuestionnaireDbContext.Options.ToListAsync();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            try
            {
                return await _lineBotQuestionnaireDbContext.Activities.Include(a => a.Questions).ToListAsync();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
