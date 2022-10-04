using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceGenAPI.Models.DataModel
{
    public enum Role
    {
        User,
        Administrator
    }

    public class User : BaseEntity
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required, StringLength(20)]
        public string UserNickName { get; set; } = string.Empty;
        [Required, StringLength(20)]
        public string UserName { get; set; } = string.Empty;
        [Required, StringLength(30)]
        public string UserLast { get; set; } = string.Empty;
        public Role UserRole { get; set; } = Role.User;
        [Required, EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
        [Required, PasswordPropertyText]
        public string UserPassword { get; set; } = string.Empty;
        public int UserPhone { get; set; }
        public ICollection<Company>? Companies { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
