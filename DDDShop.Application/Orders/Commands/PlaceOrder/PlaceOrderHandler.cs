using DDDShop.Domain.Aggregates.Orders.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace DDDShop.Application.Orders.Commands.PlaceOrder;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand>
{
    private readonly IOrderRepository _repository;

    public PlaceOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.OrderId);
        order.PlaceOrder();
        await _repository.SaveAsync(order);
        return Unit.Value;
    }
}
