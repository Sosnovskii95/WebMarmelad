using Microsoft.EntityFrameworkCore;
using WebMarmelad.Models.CodeFirst;
using WebMarmelad.Models.SolutionProblem;

namespace WebMarmelad.ProductionData
{
    public class ProductionContext : DbContext
    {
        public ProductionContext(DbContextOptions<ProductionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Production> Productions { get; set; }

        public DbSet<PropertyExpertModel> ExpertOne { get; set; }

        public DbSet<PropertyExpertModel> ExpertTwo { get; set; }
    }
}
