using Microsoft.EntityFrameworkCore;
using QuestionnaireLineBot.Dtos.Profile;
using QuestionnaireLineBot.Models;

namespace QuestionnaireLineBot.Services
{
    public interface IAccountService
    {
        Task PostAccount(UserProfileDto profil);
    }

    public class AccountService : IAccountService
    {
        private readonly LineBotQuestionnaireDbContext _lineBotQuestionnaireDbContext;
        public AccountService(LineBotQuestionnaireDbContext lineBotQuestionnaireDbContext)
        {
            _lineBotQuestionnaireDbContext = lineBotQuestionnaireDbContext;
        }

        public async Task PostAccount(UserProfileDto profile)
        {
            Account account = new Account() { AccountId = profile.userId, Name = profile.displayName };
            try
            {
                var existingEntity = await _lineBotQuestionnaireDbContext.Accounts.FindAsync(account.AccountId);
                if (existingEntity != null)
                {
                    if (existingEntity.Name != account.Name)
                    {
                        existingEntity.Name = account.Name;
                    }
                }
                else
                {
                    _lineBotQuestionnaireDbContext.Accounts.Add(account);
                }

                await _lineBotQuestionnaireDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
