using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceGenAPI.Model.DataModel
{
    public class Company : BaseEntity
    {
        [Required]
        [Key]
        public int CompanyId { get; set; }
        public int CompanyAssignedUser { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyCif { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public int CompanyPhone { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }

        [ForeignKey("CompanyAssignedUser")]
        public User? UserId { get; set; }

    }
}
