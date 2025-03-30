using System;
using DDDShop.Domain.Shared;
namespace DDDShop.Domain.Aggregates.Orders.Events;
public class OrderPlaced : IDomainEvent
{
    public Guid OrderId { get; }
    public Guid CustomerId { get; }
    public DateTime PlacedAt { get; }

    public OrderPlaced(Guid orderId, Guid customerId, DateTime placedAt)
    {
        OrderId = orderId;
        CustomerId = customerId;
        PlacedAt = placedAt;
    }
}
