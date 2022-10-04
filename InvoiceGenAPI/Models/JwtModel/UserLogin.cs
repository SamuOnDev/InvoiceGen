using System.ComponentModel.DataAnnotations;

namespace InvoiceGenAPI.Models.JwtModel
{
    public class UserLogin
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
