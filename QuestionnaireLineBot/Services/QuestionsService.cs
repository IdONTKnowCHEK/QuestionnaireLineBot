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
        Task<ActionResult<List<QuestionBank>>> GetQuestionBanks();
        Task<ActionResult<List<Option>>> GetQuestionOptions();
    }

    public class QuestionsService : IQuestionsService
    {
        private readonly QuestionnaireDbContext _questionnaireDbContext;


        public QuestionsService(QuestionnaireDbContext questionnaireDbContext)
        {
            _questionnaireDbContext = questionnaireDbContext;
        }

        public async Task<ActionResult<List<QuestionBank>>> GetQuestionBanks()
        {
            try
            {
                return await _questionnaireDbContext.QuestionBanks.ToListAsync();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<ActionResult<List<Option>>> GetQuestionOptions()
        {
            try
            {
                return await _questionnaireDbContext.Options.ToListAsync();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
