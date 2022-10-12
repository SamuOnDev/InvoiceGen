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



    }
}
