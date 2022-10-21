using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using Microsoft.EntityFrameworkCore;


namespace InvoiceGenAPI.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly InvoiceGenDBContext _context;

        public UsersService(InvoiceGenDBContext context)
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

        public async Task<User?> GetUserByIdAsync(int id)
        {
            User? user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<bool?> UpdateUserAsync(int id, UserEdit user)
        {
            var checkId = (from userCheck in _context.Users
                             where userCheck.UserId.Equals(id)
                             select userCheck).FirstOrDefault();

            if (id != checkId.UserId)
            {
                return null;
            }

            checkId.UserNickName = user.UserNickName;
            checkId.UserName = user.UserName;
            checkId.UserLast = user.UserLast;
            checkId.UserEmail = user.UserEmail; 
            checkId.UserPhone = user.UserPhone;

            if (user.UserNewPassword != string.Empty)
            {
                checkId.UserPassword = user.UserNewPassword;
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool?> DeleteUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
