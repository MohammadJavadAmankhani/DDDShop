using System;
using DDDShop.Domain.Shared;
using DDDShop.Domain.Aggregates.ShippingOrders.Enums;

namespace DDDShop.Domain.Aggregates.ShippingOrders;

public class ShippingOrder : AggregateRoot
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public ShippingStatus Status { get; private set; }

    private ShippingOrder() { }

    public static ShippingOrder Create(Guid orderId, Guid customerId)
    {
        return new ShippingOrder
        {
            Id = orderId,
            CustomerId = customerId,
            Status = ShippingStatus.Preparing
        };
    }

    public void UpdateStatus(ShippingStatus newStatus)
    {
        Status = newStatus;
    }
}
