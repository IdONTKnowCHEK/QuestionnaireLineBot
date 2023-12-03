using QuestionnaireLineBot.Dtos.Profile;
using QuestionnaireLineBot.Models;

namespace QuestionnaireLineBot.Services
{
    public interface IAccountService
    {
        void PostAccount(UserProfileDto profil);
    }

    public class AccountService: IAccountService
    {
        private readonly LineBotQuestionnaireDbContext _lineBotQuestionnaireDbContext;
        public AccountService(LineBotQuestionnaireDbContext lineBotQuestionnaireDbContext)
        {
            _lineBotQuestionnaireDbContext = lineBotQuestionnaireDbContext;
        }

        public async void PostAccount(UserProfileDto profile)
        {
            _lineBotQuestionnaireDbContext.Accounts.Add(new Account() { AccountId = profile.userId, Name = profile.userId });
            await _lineBotQuestionnaireDbContext.SaveChangesAsync();
        }
    }
}
