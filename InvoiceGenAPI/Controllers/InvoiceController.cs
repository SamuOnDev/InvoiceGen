using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using InvoiceGenAPI.Services.Invoices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceGenDBContext _context;
        private readonly IInvoicesService _invoiceService;

        public InvoiceController(InvoiceGenDBContext context, IInvoicesService invoicesService)
        {
            _context = context;
            _invoiceService = invoicesService;
        }

        [HttpGet]
        [Route("GetInvoices")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> GetCompanies()
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            var invoices = _invoiceService.GetInvoicesByUserId(tokenId);

            return Ok(invoices);
        }

       

    }
}
