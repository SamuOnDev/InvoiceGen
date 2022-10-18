namespace InvoiceGenAPI.Models.DataModel
{
    public class InvoiceDto
    {
        public int InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public int InvoiceTotalArticle { get; set; }
        public float InvoiceTotalPrice { get; set; }
        public int InvoiceTaxPercent { get; set; }
        public float InvoiceTaxPrice { get; set; }
        public float InvoicePriceWithTaxes { get; set; }
        public List<InvoiceContent>? InvoiceContents { get; set; } 
    }
}
