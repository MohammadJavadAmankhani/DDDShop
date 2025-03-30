using Microsoft.EntityFrameworkCore;
using DDDShop.Domain.Aggregates.Orders;
using DDDShop.Domain.Aggregates.BillingOrders;
using DDDShop.Domain.Aggregates.ShippingOrders;
using DDDShop.Domain.Aggregates.Orders.Entities;

namespace DDDShop.Infrastructure.Orders;

public class OrdersDbContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<BillingOrder> BillingOrders => Set<BillingOrder>();
    public DbSet<ShippingOrder> ShippingOrders => Set<ShippingOrder>();

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress);
        modelBuilder.Entity<Order>().HasMany(o => o.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}
