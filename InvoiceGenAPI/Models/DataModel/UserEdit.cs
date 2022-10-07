using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceGenAPI.Models.DataModel
{
    public class UserEdit
    {
        public string UserNickName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserLast { get; set; } = string.Empty;
        [EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
        [PasswordPropertyText]
        public string UserPassword { get; set; } = string.Empty;
        public string UserNewPassword { get; set; } = string.Empty;
        public int UserPhone { get; set; }
    }
}

