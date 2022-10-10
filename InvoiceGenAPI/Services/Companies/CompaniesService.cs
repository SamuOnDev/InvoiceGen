using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGenAPI.Services.Companies
{
    public class CompaniesService : ICompaniesService
    {
        private readonly InvoiceGenDBContext _context;

        public CompaniesService(InvoiceGenDBContext context)
        {
            _context = context;
        }

        public List<Company> GetCompaniesByUserId(int userId)
        {
            List<Company> companiesByUserId = (from company in _context.Companies
                                               where company.UserId == userId
                                               select company).ToList();

            return companiesByUserId;
        }

        public bool RegisterCompanyToDb(Company company, int tokenId)
        {
            company.UserId = tokenId;

            try
            {
                _context.Companies.Add(company);

                _context.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
