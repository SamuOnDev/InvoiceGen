using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceGenAPI.Models.DataModel
{
    public class Company : BaseEntity
    {
        [Required]
        [Key]
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyCif { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public int CompanyPhone { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
