using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CatalogService.Persistence
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(b =>
            {
                b.ToTable("Product");
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(400).IsRequired();
                b.Property(x => x.ShortDescription).HasMaxLength(1000);
                b.Property(x => x.Price).HasColumnType("decimal(18,2)");
                b.Property(x => x.Published).HasDefaultValue(true);
                b.Property(x => x.CreatedOnUtc).IsRequired();
                b.Property(x => x.UpdatedOnUtc).IsRequired();
            });
        }
    }
}
