using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using InvoiceGenAPI.Services.IContent;
using InvoiceGenAPI.Services.Invoices;

namespace InvoiceGenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceContentsController : ControllerBase
    {
        private readonly InvoiceGenDBContext _context;
        private readonly IIContentService _iContentService;
        private readonly IInvoicesService _invoiceService;

        public InvoiceContentsController(InvoiceGenDBContext context, IIContentService iContentService, IInvoicesService invoicesService)
        {
            _context = context;
            _iContentService = iContentService;
            _invoiceService = invoicesService;
        }

        [HttpGet]
        [Route("GetInvoiceContent/{invoiceId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<IActionResult> GetInvoiceContentById(int invoiceId)
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            Console.WriteLine($"Factura numer:{invoiceId}");

            List<InvoiceContent> invoiceContent = _iContentService.GetInvoiceContentById(invoiceId, tokenId);

            if (invoiceContent == null)
            {
                return NotFound();
            }

            return Ok(invoiceContent);
        }

        [HttpPost]
        [Route("SaveInvoiceContent")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
        public async Task<ActionResult<InvoiceContent>> PostInvoiceContent(InvoiceDto invoiceDto)
        {
            int tokenId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            Invoice savedInvoice = _invoiceService.SaveInvoiceToDb(invoiceDto, tokenId);

            if (savedInvoice is null) return BadRequest("Error saving invoice");

            bool savedContent = _iContentService.SaveInvoiceContentToDb(savedInvoice, invoiceDto, tokenId);

            if (savedContent is false) return BadRequest("Error creating products");

            return Ok();
            
        }
    }
}
