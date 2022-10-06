using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Models.JwtModel;

namespace InvoiceGenAPI.Services.Account
{
    public interface IAccountService
    {
        UserToken UserLogin(UserLogin userLogin);
    }
}
