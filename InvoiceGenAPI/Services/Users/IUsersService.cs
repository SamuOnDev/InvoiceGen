using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.Users
{
    public interface IUsersService
    {
        bool CheckIfUserNameExist(string userName);
        bool CheckIfEmailExist(string userEmail);
        bool RegisterUserToDb(User user);
        Task<User?> GetUserByIdAsync(int id);
    }
}
