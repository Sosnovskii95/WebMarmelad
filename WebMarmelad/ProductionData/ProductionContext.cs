using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebMarmelad.Models.CodeFirst;
using WebMarmelad.Models.PropertyValueExpert;

namespace WebMarmelad.ProductionData
{
    public class ProductionContext : DbContext
    {
        public ProductionContext(DbContextOptions<ProductionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Production> Productions { get; set; }

        public DbSet<PropertyExpertModel> Expert { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyExpertModel>().HasData(PropertyExpertUtil.GetDefaultPropertyExpertList());
            modelBuilder.Entity<Production>().HasData(Create(100));
        }

        private List<Production> Create(int count)
        {
            Random random = new Random();
            List<Production> productionList = new List<Production>(count);

            for (int i = 0; i < count; i++)
            {
                bool air = true;
                if (i % 2 == 0)
                {
                    air = false;
                }
                productionList.Add(new Production
                {
                    Id = i + 1,
                    Name = "Линия " + (i + 1).ToString(),
                    Cost = random.Next(1, 100) * random.Next(1, 100),
                    Power = random.Next(1, 10000),
                    Water = random.Next(1, 1000),
                    Air = air,
                    PowerCount = random.Next(1, 10000),
                    PowerTime = random.Next(1, 1000),
                    Weight = 0
                });
            }

            return productionList;
        }
    }
}
