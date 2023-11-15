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
        private readonly QuestionnaireDbContext _questionnaireDbContext;
        public AccountService(QuestionnaireDbContext questionnaireDbContext)
        {
            _questionnaireDbContext = questionnaireDbContext;
        }

        public async void PostAccount(UserProfileDto profile)
        {
            _questionnaireDbContext.AccountPeople.Add(new AccountPerson() { Account = profile.userId, Name = profile.userId });
            await _questionnaireDbContext.SaveChangesAsync();
        }
    }
}
