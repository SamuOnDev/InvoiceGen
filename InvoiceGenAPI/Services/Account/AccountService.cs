using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Models.JwtModel;

namespace InvoiceGenAPI.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly InvoiceGenDBContext _context;

        public AccountService(InvoiceGenDBContext context)
        {
            _context = context;
        }
        public bool CheckIfEmailExist(string userEmail)
        {
            var EmailFound = (from user in _context.Users
                              where user.UserEmail.Equals(userEmail)
                              select user).FirstOrDefault();

            if (EmailFound is null)
            {
                return false;
            }

            return true;
        }

        public bool CheckIfUserNameExist(string userNickName)
        {
            var UserNickNameFound = (from user in _context.Users
                                 where user.UserNickName.Equals(userNickName)
                                 select user).FirstOrDefault();

            if (UserNickNameFound is null)
            {
                return false;
            }

            return true;
        }

        public bool RegisterUserToDb(User user)
        {
             try
            {
                _context.Users.Add(user);

                _context.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
