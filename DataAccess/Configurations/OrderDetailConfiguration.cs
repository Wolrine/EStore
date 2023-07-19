using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(e => new
        {
            e.OrderId,
            e.ProductId
        });

        builder.Property(e => e.UnitPrice).HasColumnType("MONEY");

        #region SeedingData
        builder.HasData(
            new { OrderId = 1, ProductId = 1, UnitPrice = 600_000.0, Quantity = 3, Discount = 0f },
            new { OrderId = 2, ProductId = 2, UnitPrice = 500_000.0, Quantity = 5, Discount = 0f },
            new { OrderId = 3, ProductId = 3, UnitPrice = 200_000.0, Quantity = 10, Discount = 0f }
        );
        #endregion
    }
}
