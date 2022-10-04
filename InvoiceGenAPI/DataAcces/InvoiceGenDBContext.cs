using InvoiceGenAPI.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGenAPI.DataAcces
{
    public class InvoiceGenDBContext : DbContext
    {
        public InvoiceGenDBContext(DbContextOptions<InvoiceGenDBContext> options) : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<InvoiceContent>? InvoicesContent { get; set; }
        
    }
}
