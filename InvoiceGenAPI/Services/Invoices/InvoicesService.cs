using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.Invoices
{
    public class InvoicesService : IInvoicesService
    {
        private readonly InvoiceGenDBContext _context;

        public InvoicesService(InvoiceGenDBContext context)
        {
            _context = context;
            
        }

        public Invoice SaveInvoiceToDb(InvoiceDto invoiceDto, int tokenId)
        {
            Invoice invoice = new Invoice();
            invoice.CompanyId = invoiceDto.CompanyId;
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
