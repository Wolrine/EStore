using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.CompanyName).HasMaxLength(40);
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.Country).HasMaxLength(15);
            builder.Property(e => e.Password).HasMaxLength(30);

            #region SeedingData
            builder.HasData(
                new() { MemberId = 1, Email = "lamvd@gmail.com", CompanyName = "MangaNexus", City = "Huế", Country = "Việt Nam", Password = "123123" },
                new() { MemberId = 2, Email = "nghialt@gmail.com", CompanyName = "MangaNexus", City = "Quảng Ngãi", Country = "Việt Nam", Password = "123123" },
                new() { MemberId = 3, Email = "khoaldd@gmail.com", CompanyName = "MangaNexus", City = "Huế", Country = "Việt Nam", Password = "123123" },
                new() { MemberId = 4, Email = "minhth@gmail.com", CompanyName = "MangaNexus", City = "Đà Nẵng", Country = "Việt Nam", Password = "123123" },
                new() { MemberId = 5, Email = "thanhtt@gmail.com", CompanyName = "MangaNexus", City = "Quảng Bình", Country = "Việt Nam", Password = "123123" }
            );
            #endregion
        }
    }
}
