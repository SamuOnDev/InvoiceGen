using System.ComponentModel.DataAnnotations;

namespace InvoiceGenAPI.Model.DataModel
{
    public class Invoice : BaseEntity
    {
        [Required]
        [Key]
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Company? InvoiceCompany { get; set; }
        public User? InvoiceUser { get; set; }
    }
}
