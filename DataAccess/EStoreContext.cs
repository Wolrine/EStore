using BusinessObject;
using DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class EStoreContext : DbContext
{
    // <summary>
    // Representation DbSet of each table
    // </summary>
    #region DbSet
    public DbSet<Member> Members { get; private set; }
    public DbSet<Order> Orders { get; private set; }
    public DbSet<Product> Products { get; private set; }
    public DbSet<OrderDetail> OrderDetails { get; private set; }
    #endregion

    public EStoreContext() { }

    public EStoreContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQL"));
        optionsBuilder.EnableSensitiveDataLogging(true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Configuration
        modelBuilder
            .ApplyConfiguration(configuration: new MemberConfiguration())
            .ApplyConfiguration(configuration: new OrderConfiguration())
            .ApplyConfiguration(configuration: new OrderDetailConfiguration())
            .ApplyConfiguration(configuration: new ProductConfiguration());
        #endregion
    }
}
