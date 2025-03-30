using System;
using DDDShop.Domain.Shared;

namespace DDDShop.Domain.Aggregates.BillingOrders.Events;

public class OrderPaid : IDomainEvent
{
    public Guid OrderId { get; }
    public Guid CustomerId { get; }
    public DateTime PaidAt { get; }

    public OrderPaid(Guid orderId, Guid customerId, DateTime paidAt)
    {
        OrderId = orderId;
        CustomerId = customerId;
        PaidAt = paidAt;
    }
}
