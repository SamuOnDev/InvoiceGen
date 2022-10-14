using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.Invoices
{
    public interface IInvoicesService
    {
        List<Invoice> GetInvoicesByUserId(int tokenId);
        Invoice SaveInvoiceToDb(InvoiceDto invoiceDto, int tokenId);
    }
}
