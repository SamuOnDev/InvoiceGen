using System.ComponentModel.DataAnnotations;

namespace InvoiceGenAPI.Models.DataModel
{
    public class InvoiceContent
    {
        [Required]
        [Key]
        public int IContentId { get; set; }
        public int InvoiceId { get; set; }
        public int IContentArticleNumber { get; set; }
        public string IContentDescription { get; set; } = string.Empty;
        public int IContentQuantity { get; set; }
        public float IContentUnitPrice { get; set; }
        public int IContentDiscount { get; set; }
        public float IContentPrice { get; set; }
    }
}