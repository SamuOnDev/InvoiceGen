using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.Companies
{
    public interface ICompaniesService
    {
        bool RegisterCompanyToDb(Company company, int tokenId);
        List<Company> GetCompaniesByUserId(int userId);
    }
}
