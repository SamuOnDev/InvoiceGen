using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Services.Companies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;

namespace InvoiceGenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly InvoiceGenDBContext _context;
        private readonly ICompaniesService _companiesService;

        public CompaniesController(InvoiceGenDBContext context, ICompaniesService companiesService)
        {
            _context = context;
            _companiesService = companiesService;
        }

        [HttpGet]
        [Route("GetCompanies/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> GetCompanies(int id)
        {
            if (id == 0)
            {
                int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

                List<Company> companies = _companiesService.GetCompaniesByUserId(tokenId);

                return Ok(companies);
            }
            else
            {
                List<Company> companies = _companiesService.GetCompaniesByUserId(id);

                return Ok(companies);
            }
        }


        [HttpGet]
        [Route("GetCompany/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<ActionResult<Company>> GetCompanyById(int id)
        {
            string userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (userRole != "Administrator")
            {
                int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

                Company company = _companiesService.GetCompanyById(id, tokenId);

                if (company == null)
                {
                    return NotFound();
                }

                return company;
            }

            Company companyAdmin = _companiesService.GetCompanyByIdAdmin(id);

            if (companyAdmin == null)
            {
                return NotFound();
            }

            return companyAdmin;
        }

        [HttpPut]
        [Route("UpdateCompany")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> PutCompany(Company company)
        {
            string userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (userRole != "Administrator")
            {
                int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

                bool? updatedSucces = await _companiesService.UpdateCompanyByIdAsync(company, tokenId);

                if (updatedSucces is null) { return NotFound("Company not found"); }
                if (updatedSucces is false) { return BadRequest("Company not exist"); }

                return Ok();
            }

            bool? updatedSuccesAdmin = await _companiesService.UpdateCompanyByIdAdminAsync(company);

            if (updatedSuccesAdmin is null) { return NotFound("Company not found"); }
            if (updatedSuccesAdmin is false) { return BadRequest("Company not exist"); }

            return Ok();

        }

        [HttpPost]
        [Route("CreateCompany")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            if (!_companiesService.RegisterCompanyToDb(company, tokenId))
            {
                return BadRequest("Error creating company");
            }

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCompany/{companyId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            string userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (userRole != "Administrator")
            {
                int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

                bool? deleted = await _companiesService.DeleteCompanyByIdAsync(companyId, tokenId);

                if (deleted is false)
                {
                    return BadRequest("Something went wrong company not deleted");
                }
                else if (deleted is null)
                {
                    return NotFound("Company not found");
                }

                return Ok();
            }

            bool? deletedAdmin = await _companiesService.DeleteCompanyByIdAdminAsync(companyId);

            if (deletedAdmin is false)
            {
                return BadRequest("Something went wrong company not deleted");
            }
            else if (deletedAdmin is null)
            {
                return NotFound("Company not found");
            }

            return Ok();
        }        
    }
}
