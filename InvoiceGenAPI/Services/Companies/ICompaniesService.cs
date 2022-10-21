using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.Companies
{
    public interface ICompaniesService
    {
        bool RegisterCompanyToDb(Company company, int tokenId);
        List<Company> GetCompaniesByUserId(int userId);
        Company GetCompanyById(int companyId, int tokenId);
        Task<bool?> UpdateCompanyByIdAsync(Company company, int userId);
        Task<bool?> DeleteCompanyByIdAsync(int companyId, int userId);
        Company GetCompanyByIdAdmin(int companyId);
        Task<bool?> UpdateCompanyByIdAdminAsync(Company company);
        Task<bool?> DeleteCompanyByIdAdminAsync(int companyId);
    }
}
