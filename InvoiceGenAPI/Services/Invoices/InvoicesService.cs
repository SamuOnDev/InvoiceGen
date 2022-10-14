using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using System.ComponentModel.Design;

namespace InvoiceGenAPI.Services.Invoices
{
    public class InvoicesService : IInvoicesService
    {
        private readonly InvoiceGenDBContext _context;

        public InvoicesService(InvoiceGenDBContext context)
        {
            _context = context;
            
        }

        public List<Invoice> GetInvoicesByUserId(int tokenId)
        {
            List<Invoice> companiesByUserId = (from invoice in _context.Invoices
                                               where invoice.UserId == tokenId
                                               select invoice).OrderByDescending(x => x.InvoiceId).ToList(); ;

            return companiesByUserId;
        }

        public Invoice SaveInvoiceToDb(InvoiceDto invoiceDto, int tokenId)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceDate = invoiceDto.InvoiceDate;
            invoice.CompanyId = invoiceDto.CompanyId;
            invoice.CompanyName = invoiceDto.CompanyName;
            invoice.UserId = tokenId;
            invoice.InvoiceTotalArticle = invoiceDto.InvoiceTotalArticle;
            invoice.InvoiceTotalPrice = invoiceDto.InvoiceTotalPrice;

            _context.Invoices.Add(invoice);

            _context.SaveChanges();

            invoice.InvoiceNumber = $"{invoice.UserId.ToString().PadLeft(3, '0')}-{invoice.InvoiceId.ToString().PadLeft(4, '0')}";

            _context.SaveChanges();

            return invoice;
        }
    }
}
