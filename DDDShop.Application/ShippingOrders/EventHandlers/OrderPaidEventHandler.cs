using System.Threading;
using System.Threading.Tasks;
using DDDShop.Application.ShippingOrders.Notifications;
using DDDShop.Domain.Aggregates.ShippingOrders;
using DDDShop.Domain.Aggregates.ShippingOrders.Interfaces;
using MediatR;

namespace DDDShop.Application.ShippingOrders.EventHandlers.Internal
{
    public class OrderPaidEventHandler : INotificationHandler<OrderPaidNotification>
    {
        private readonly IShippingOrderRepository _repository;

        public OrderPaidEventHandler(IShippingOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(OrderPaidNotification notification, CancellationToken cancellationToken)
        {
            var shippingOrder = ShippingOrder.Create(notification.OrderId, notification.CustomerId);
            await _repository.AddAsync(shippingOrder);
        }
    }
}
