using CatMash.Domain.Entities.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatMash.Infrastructure.Data.Configuration
{
    public class CatConfiguration : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
            builder
            .HasKey(m => m.Id);

            builder
                .Property(m => m.Url)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .Property(m => m.Score)
                .HasDefaultValueSql("0");

            builder
                .ToTable("Cats");
        }
    }
}