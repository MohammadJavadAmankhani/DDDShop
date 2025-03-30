// Application Layer
using System;
using MediatR;

namespace DDDShop.Application.ShippingOrders.Notifications;

public class OrderPaidNotification : INotification
{
    public Guid OrderId { get; }
    public Guid CustomerId { get; }
    public DateTime PaidAt { get; }

    public OrderPaidNotification(Guid orderId, Guid customerId, DateTime paidAt)
    {
        OrderId = orderId;
        CustomerId = customerId;
        PaidAt = paidAt;
    }
}
