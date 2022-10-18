using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceGenAPI.Models.DataModel
{
    public class Invoice : BaseEntity
    {
        [Required]
        [Key]
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string InvoiceDate { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public int InvoiceTotalArticle { get; set; }
        public float InvoiceTotalPrice { get; set; }
        [DefaultValue(21)]
        public int InvoiceTaxPercent { get; set; }
        public float InvoiceTaxPrice { get; set; }
        public float InvoicePriceWithTaxes { get; set; }



    }
}