using CatMash.Domain.Entities.DTO;
using CatMash.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CatMash.Infrastructure.Data.Context
{
    public class CatMashDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        public CatMashDbContext(DbContextOptions<CatMashDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
              .ApplyConfiguration(new CatConfiguration());
        }
    }
}