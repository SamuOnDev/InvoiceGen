using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.Account
{
    public interface IAccountService
    {
        bool CheckIfUserNameExist(string userName);
        bool CheckIfEmailExist(string userEmail);
        User RegisterUserToDb(User user);
    }
}
