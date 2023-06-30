using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class CRUDDbContext : DbContext
    {
        public CRUDDbContext(DbContextOptions<CRUDDbContext> options)
        : base(options) { }

        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
