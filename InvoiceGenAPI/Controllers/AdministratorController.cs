using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Services.Administrator;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly InvoiceGenDBContext _context;
        private readonly IAdministratorService _administratorService;

        public AdministratorController(InvoiceGenDBContext context, IAdministratorService administratorService)
        {
            _context = context;
            _administratorService = administratorService;
        }

        // GET: api/Users
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _administratorService.GetUsers();

            return Ok(users);
        }
    }
}
