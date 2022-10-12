using InvoiceGenAPI.DataAcces;
using InvoiceGenAPI.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InvoiceGenAPI.Services.IContent
{
    public class IContentService : IIContentService
    {
        private readonly InvoiceGenDBContext _context;

        public IContentService(InvoiceGenDBContext context) 
        {
            _context = context;
        }
        public bool SaveInvoiceContentToDb(Invoice savedInvoice, InvoiceDto invoiceDto, int tokenId)
        {
            foreach (InvoiceContent product in invoiceDto.InvoiceContents)
            {
                InvoiceContent productToSave = new InvoiceContent();
                productToSave.InvoiceId = savedInvoice.InvoiceId;
                productToSave.IContentArticleNumber = product.IContentArticleNumber;
                productToSave.IContentDescription = product.IContentDescription;
                productToSave.IContentQuantity = product.IContentQuantity;
                productToSave.IContentUnitPrice = product.IContentUnitPrice;
                productToSave.IContentDiscount = product.IContentDiscount;
                productToSave.IContentPrice = product.IContentPrice;

                _context.InvoicesContent.Add(productToSave);
            }

            try
            {
                _context.SaveChanges();

                return true;

            }
            catch(Exception exce)
            {
                return false;
            }
            


             
            
        }
    }
}
