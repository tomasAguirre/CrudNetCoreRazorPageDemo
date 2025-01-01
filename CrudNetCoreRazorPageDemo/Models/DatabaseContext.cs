using Microsoft.EntityFrameworkCore;

namespace CrudNetCoreRazorPageDemo.Models
{
    public class DatabaseContext : DbContext
    { 
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
