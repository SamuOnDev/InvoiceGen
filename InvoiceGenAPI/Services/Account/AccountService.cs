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
