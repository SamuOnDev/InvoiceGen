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

        // GET: api/InvoiceContents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceContent>>> GetInvoicesContent()
        {
            return await _context.InvoicesContent.ToListAsync();
        }

        // GET: api/InvoiceContents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceContent>> GetInvoiceContent(int id)
        {
            var invoiceContent = await _context.InvoicesContent.FindAsync(id);

            if (invoiceContent == null)
            {
                return NotFound();
            }

            return invoiceContent;
        }

        // PUT: api/InvoiceContents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceContent(int id, InvoiceContent invoiceContent)
        {
            if (id != invoiceContent.IContentId)
            {
                return BadRequest();
            }

            _context.Entry(invoiceContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceContentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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

        // DELETE: api/InvoiceContents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceContent(int id)
        {
            var invoiceContent = await _context.InvoicesContent.FindAsync(id);
            if (invoiceContent == null)
            {
                return NotFound();
            }

            _context.InvoicesContent.Remove(invoiceContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceContentExists(int id)
        {
            return _context.InvoicesContent.Any(e => e.IContentId == id);
        }
    }
}
