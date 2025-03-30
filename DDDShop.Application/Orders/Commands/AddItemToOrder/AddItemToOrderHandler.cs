using DDDShop.Domain.Aggregates.Orders.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace DDDShop.Application.Orders.Commands.AddItemToOrder;

public class AddItemToOrderHandler : IRequestHandler<AddItemToOrderCommand>
{
    private readonly IOrderRepository _repository;

    public AddItemToOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddItemToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.OrderId);
        order.AddItem(request.ProductId, request.Name, request.UnitPrice, request.Quantity);
        await _repository.SaveAsync(order);
        return Unit.Value;
    }
}
