using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.IContent
{
    public interface IIContentService
    {
        bool SaveInvoiceContentToDb(Invoice savedInvoice, InvoiceDto invoiceDto, int tokenId);
    }
}
