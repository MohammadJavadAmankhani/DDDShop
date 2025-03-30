using Xunit;
using DDDShop.Domain.Aggregates.ShippingOrders;
using System;
using DDDShop.Domain.Aggregates.ShippingOrders.Enums;

namespace DDDShop.Tests.Aggregates.ShippingOrders;

public class ShippingOrderTests
{
    [Fact]
    public void CreateShippingOrder_ShouldSetStatusToPreparing()
    {
        var shipping = ShippingOrder.Create(Guid.NewGuid(), Guid.NewGuid());

        Assert.Equal(ShippingStatus.Preparing, shipping.Status);
    }

    [Fact]
    public void UpdateStatus_ShouldChangeShippingStatus()
    {
        var shipping = ShippingOrder.Create(Guid.NewGuid(), Guid.NewGuid());

        shipping.UpdateStatus(ShippingStatus.Shipped);

        Assert.Equal(ShippingStatus.Shipped, shipping.Status);
    }

}
