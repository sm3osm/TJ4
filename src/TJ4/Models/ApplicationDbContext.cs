using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace TJ4.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Customer> Customer { get; set; }
    }
}
