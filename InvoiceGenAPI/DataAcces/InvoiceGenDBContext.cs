using Microsoft.EntityFrameworkCore;

namespace InvoiceGenAPI.DataAcces
{
    public class InvoiceGenDBContext : DbContext
    {
        public InvoiceGenDBContext(DbContextOptions<InvoiceGenDBContext> options) : base(options)
        {

        }

        // TODO: Add DbSets
    }
}
