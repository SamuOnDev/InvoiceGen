using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace InvoiceGenAPI.Model.DataModel
{
    public class User : BaseEntity
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(30)]
        public string UserLast { get; set; } = string.Empty;
        public int UserRole { get; set; } = 0;
        [EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public int UserPhone { get; set; }
        public ICollection<Company>? Companies { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
