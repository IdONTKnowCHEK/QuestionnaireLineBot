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
        Task<ActionResult<List<Questions>>> GetAsync();
    }

    public class QuestionsService : IQuestionsService
    {
        private readonly QuestionnaireDbContext _questionnaireDbContext;


        public QuestionsService(QuestionnaireDbContext questionnaireDbContext)
        {
            _questionnaireDbContext = questionnaireDbContext;
        }
        public async Task<ActionResult<List<Questions>>> GetAsync()
        {
            return await GetQuestions();
        }

        public async Task<ActionResult<List<Questions>>> GetQuestions()
        {
            var questionBanksResult = await GetQuestionBanks();
            var optionsResult = await GetQuestionOptions();

            var questionBanks = questionBanksResult.Value as List<QuestionBank>;
            var options = optionsResult.Value as List<Option>;

            if (questionBanks != null && options != null)
            {
                var result = from q in questionBanks
                             join o in options on q.QuestionId equals o.QuestionId into joined
                             select new Questions
                             {
                                 QuestionId = q.QuestionId,
                                 Question = q.Question,
                                 Options = joined.Select(x => x.Item).ToList(),
                                 Answer = q.Answer
                             };

                return result.ToList();
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
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
