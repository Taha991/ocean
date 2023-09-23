using Microsoft.EntityFrameworkCore;
using oceantecsa.Models;

namespace oceantecsa.Data
{
    public class CasherDbContext :DbContext
    {
        public CasherDbContext(DbContextOptions<CasherDbContext> options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Product)
                .WithMany() // Assuming a one-to-many relationship
                .HasForeignKey(s => s.ProductId);
        }
    }
}
