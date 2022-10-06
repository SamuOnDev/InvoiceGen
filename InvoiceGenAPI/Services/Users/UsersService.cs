using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Models.JwtModel;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGenAPI.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly InvoiceGenDBContext _context;
        private readonly JwtSettings _jwtSettings;

        public UsersService(InvoiceGenDBContext context, JwtSettings jwtSettings)
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

        public async Task<User?> GetUserByIdAsync(int id)
        {
            User? user = await _context.Users.FindAsync(id);

            return user;
        }
    }
}
