using InvoiceGenAPI.Models.DataModel;

namespace InvoiceGenAPI.Services.IContent
{
    public interface IIContentService
    {
        bool SaveInvoiceContentToDb(Invoice savedInvoice, InvoiceDto invoiceDto, int tokenId);
        List<InvoiceContent> GetInvoiceContentById(int invoiceId, int tokenId);
    }
}
