using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.Invoices
{
    public interface IInvoicesService
    {
        Invoice SaveInvoiceToDb(InvoiceDto invoiceDto, int tokenId);
    }
}
