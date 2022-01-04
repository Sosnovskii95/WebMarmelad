using Microsoft.EntityFrameworkCore;
using WebMarmelad.Models.CodeFirst;

namespace WebMarmelad.ProductionData
{
    public class ProductionContext : DbContext
    {
        public ProductionContext(DbContextOptions<ProductionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Production> Productions { get; set; }
    }
}
