using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Services.Companies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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

        // GET: api/Companies
        [HttpGet]
        [Route("GetCompanies")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> GetCompanies()
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            var users = _companiesService.GetCompaniesByUserId(tokenId);

            return Ok(users);
        }


        // GET: api/Companies/5
        [HttpGet]
        [Route("GetCompany/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<ActionResult<Company>> GetCompanyById(int id)
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            var company = _companiesService.GetCompanyById(id, tokenId);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("UpdateCompany")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> PutCompany(Company company)
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            bool? updatedSucces = await _companiesService.UpdateCompanyByIdAsync(company, tokenId);

            if (updatedSucces is null) { return NotFound("Company not found"); }
            if (updatedSucces is false) { return BadRequest("Company not exist"); }

            return Ok();
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // DELETE: api/Companies/5
        [HttpDelete]
        [Route("DeleteCompany/{companyId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            Console.WriteLine(companyId);
            bool? deleted = await _companiesService.DeleteCompanyByIdAsync(companyId, tokenId);

            if (deleted is false)
            {
                return BadRequest("Something went wrong company not deleted");
            }else if(deleted is null){
                return NotFound("Company not found");
            }

            return Ok();
        }

        
    }
}
