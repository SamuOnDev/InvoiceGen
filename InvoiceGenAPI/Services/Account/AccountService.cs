using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Helpers;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Models.JwtModel;

namespace InvoiceGenAPI.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly InvoiceGenDBContext _context;
        private readonly JwtSettings _jwtSettings;

        public AccountService(InvoiceGenDBContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;            
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

        public UserToken UserLogin(UserLogin userLogin)
        {
            try
            {
                User? userDb = (from user in _context.Users
                                where user.UserEmail == userLogin.UserEmail && user.UserPassword == userLogin.UserPassword
                                select user).FirstOrDefault();

                if (userDb is null)
                {
                    return null;
                }

                return (JwtHelpers.GenTokenKey(userDb, _jwtSettings));

            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }
    }
}
