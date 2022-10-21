using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public Company GetCompanyById(int companyId, int tokenId)
        {
            Company? companyFound = (from company in _context.Companies
                               where company.UserId == tokenId && company.CompanyId == companyId
                               select company).FirstOrDefault();

            if (companyFound is null) return null;
            
            return companyFound;
        }

        public Company GetCompanyByIdAdmin(int companyId)
        {
            Company? companyFound = (from company in _context.Companies
                                     where company.CompanyId == companyId
                                     select company).FirstOrDefault();

            if (companyFound is null) return null;

            return companyFound;
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

        public async Task<bool?> UpdateCompanyByIdAsync(Company company, int userId)
        {
            Company? companyToUpdate = (from compCheck in _context.Companies
                             where compCheck.CompanyId.Equals(company.CompanyId) && compCheck.UserId.Equals(userId)
                             select compCheck).FirstOrDefault();

            if (companyToUpdate is null) return null; 

            companyToUpdate.CompanyId = company.CompanyId;
            companyToUpdate.CompanyName = company.CompanyName;
            companyToUpdate.CompanyCif = company.CompanyCif;
            companyToUpdate.CompanyEmail = company.CompanyEmail;
            companyToUpdate.CompanyPhone = company.CompanyPhone;
            companyToUpdate.CompanyAddress = company.CompanyAddress;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(company.CompanyId))
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

        public async Task<bool?> UpdateCompanyByIdAdminAsync(Company company)
        {
            Company? companyToUpdate = (from compCheck in _context.Companies
                                        where compCheck.CompanyId.Equals(company.CompanyId)
                                        select compCheck).FirstOrDefault();

            if (companyToUpdate is null) return null;

            companyToUpdate.CompanyId = company.CompanyId;
            companyToUpdate.CompanyName = company.CompanyName;
            companyToUpdate.CompanyCif = company.CompanyCif;
            companyToUpdate.CompanyEmail = company.CompanyEmail;
            companyToUpdate.CompanyPhone = company.CompanyPhone;
            companyToUpdate.CompanyAddress = company.CompanyAddress;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(company.CompanyId))
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

        public async Task<bool?> DeleteCompanyByIdAsync(int companyId, int userId)
        {
           
            Company? companyToDelete = _context.Companies.Find(companyId);

            if (companyToDelete is null) return null;

            if (companyToDelete.UserId == userId)
            {
                _context.Companies.Remove(companyToDelete);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool?> DeleteCompanyByIdAdminAsync(int companyId)
        {

            Company? companyToDelete = _context.Companies.Find(companyId);

            if (companyToDelete is null) return null;

            _context.Companies.Remove(companyToDelete);

            await _context.SaveChangesAsync();

            return true;
            

            return false;
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }
    }
}
