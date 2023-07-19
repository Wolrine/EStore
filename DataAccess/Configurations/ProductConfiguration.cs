using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(e => e.ProductName).HasMaxLength(40);
        builder.Property(e => e.Weight).HasMaxLength(20);
        builder.Property(e => e.UnitPrice).HasColumnType("MONEY");

        #region SeedingData
        builder.HasData(
            new() { ProductId = 1, CategoryId = 1, ProductName = "Cay", UnitPrice = 200_000.0, Weight = "200", UnitsInStock = 1 },
            new() { ProductId = 2, CategoryId = 2, ProductName = "Da", UnitPrice = 100_000.0, Weight = "200", UnitsInStock = 1 },
            new() { ProductId = 3, CategoryId = 3, ProductName = "Co", UnitPrice = 20_000.0, Weight = "10", UnitsInStock = 1 }
        );
        #endregion
    }
}
