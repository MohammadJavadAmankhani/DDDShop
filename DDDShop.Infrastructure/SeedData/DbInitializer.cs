using DDDShop.Domain.Aggregates.Orders;
using DDDShop.Domain.Aggregates.BillingOrders;
using DDDShop.Domain.Aggregates.ShippingOrders;
using DDDShop.Domain.Aggregates.Orders.ValueObjects;
using DDDShop.Infrastructure.Orders;
using Microsoft.EntityFrameworkCore;
using System;

namespace DDDShop.Infrastructure.SeedData;

public static class DbInitializer
{
    public static void Seed(OrdersDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Orders.Any())
        {
            var customerId = Guid.NewGuid();

            var address = new Address(
                street: "Saadat Abad",
                city: "Tehran",
                postalCode: "199794",
                country: "Iran"
            );

            var order = Order.CreateDraft(customerId);
            order.ChangeAddress(address);

            order.AddItem(Guid.NewGuid(), "Laptop", 25000000, 1);
            order.AddItem(Guid.NewGuid(), "Mouse", 300000, 2);

            context.Orders.Add(order);

            var totalAmount = order.Items.Sum(i => i.UnitPrice * i.Quantity);
            var billing = BillingOrder.Create(order.Id, customerId, totalAmount);
            billing.MarkAsPaid();
            context.BillingOrders.Add(billing);

            var shipping = ShippingOrder.Create(order.Id, customerId);
            context.ShippingOrders.Add(shipping);

            context.SaveChanges();
        }
    }
}
