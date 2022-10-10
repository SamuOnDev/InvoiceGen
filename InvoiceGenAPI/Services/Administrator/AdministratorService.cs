using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGenAPI.Services.Administrator
{
    public class AdministratorService : IAdministratorService
    {
        private readonly InvoiceGenDBContext _context;

        public AdministratorService(InvoiceGenDBContext context)
        {
            _context = context;

        }

        public List<User> GetUsers()
        {
            List<User> searchAllUsers = (from user in _context.Users select user).ToList();

            return searchAllUsers;
        }
    }
}
