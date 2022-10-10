using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.Administrator
{
    public interface IAdministratorService
    {
        List<User> GetUsers();
    }
}
