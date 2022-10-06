using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Models.JwtModel;

namespace InvoiceGenAPI.Services.Account
{
    public interface IAccountService
    {
        bool CheckIfUserNameExist(string userName);
        bool CheckIfEmailExist(string userEmail);
        bool RegisterUserToDb(User user);

        UserToken UserLogin(UserLogin userLogin);
    }
}
