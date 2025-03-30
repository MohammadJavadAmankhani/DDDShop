using Xunit;
using DDDShop.Domain.Aggregates.Orders;
using DDDShop.Domain.Aggregates.Orders.ValueObjects;
using System;

namespace DDDShop.Tests.Aggregates.Orders;

public class OrderTests
{
    [Fact]
    public void CreateOrder_ShouldInitializeWithAddress_AndEmptyItems()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var address = new Address("Street", "City", "12345", "Country");

        // Act
        var order = Order.CreateDraft(customerId);
        order.ChangeAddress(address);
        // Assert
        Assert.Equal(customerId, order.CustomerId);
        Assert.Equal(address, order.ShippingAddress);
        Assert.Empty(order.Items);
    }

    [Fact]
    public void AddItem_ShouldAddCorrectItem()
    {
        var order = Order.CreateDraft(Guid.NewGuid());
        var productId = Guid.NewGuid();

        order.AddItem(productId, "Product", 1000, 2);

        Assert.Single(order.Items);
        var item = order.Items[0];
        Assert.Equal(productId, item.ProductId);
        Assert.Equal(1000, item.UnitPrice);
        Assert.Equal(2, item.Quantity);
    }
}
