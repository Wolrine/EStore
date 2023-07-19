using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Freight).HasColumnType("MONEY");

            builder
                .HasOne(e => e.Member)
                .WithMany()
                .HasForeignKey(e => e.MemberId);

            #region SeedingData
            builder.HasData(
                new { OrderId = 1, MemberId = 1, Freight = 20_000.0, OrderDate = new DateTime(2021, 3, 12) },
                new { OrderId = 2, MemberId = 2, Freight = 50_000.0, OrderDate = new DateTime(2022, 3, 10) },
                new { OrderId = 3, MemberId = 3, Freight = 20_000.0, OrderDate = new DateTime(2021, 4, 15) }
            );
            #endregion
        }
    }
}
