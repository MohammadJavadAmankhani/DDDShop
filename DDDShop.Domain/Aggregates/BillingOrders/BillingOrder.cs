using System;
using DDDShop.Domain.Aggregates.BillingOrders.Enums;
using DDDShop.Domain.Aggregates.BillingOrders.Events;
using DDDShop.Domain.Shared;
namespace DDDShop.Domain.Aggregates.BillingOrders;

public class BillingOrder : AggregateRoot
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public PaymentStatus Status { get; private set; }

    private BillingOrder() { }

    public static BillingOrder Create(Guid orderId, Guid customerId, decimal totalAmount)
    {
        return new BillingOrder
        {
            Id = orderId,
            CustomerId = customerId,
            TotalAmount = totalAmount,
            Status = PaymentStatus.Pending
        };
    }

    public void MarkAsPaid()
    {
        if (Status == PaymentStatus.Paid)
            return;

        Status = PaymentStatus.Paid;
        RaiseDomainEvent(new OrderPaid(Id, CustomerId, DateTime.UtcNow));
    }
}
