namespace DDDShop.Application.Common.Events;

using DDDShop.Application.ShippingOrders.Notifications;
using DDDShop.Domain.Shared;
using DDDShop.Domain.Aggregates.BillingOrders.Events;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            // Map domain event to MediatR notification
            switch (domainEvent)
            {
                case OrderPaid paid:
                    var notification = new OrderPaidNotification(paid.OrderId, paid.CustomerId, paid.PaidAt);
                    await _mediator.Publish(notification);
                    break;
            }
        }
    }
}
