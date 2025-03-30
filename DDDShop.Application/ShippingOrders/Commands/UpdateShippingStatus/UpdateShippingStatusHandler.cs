using DDDShop.Domain.Aggregates.ShippingOrders.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace DDDShop.Application.ShippingOrders.Commands.UpdateShippingStatus;

public class UpdateShippingStatusHandler : IRequestHandler<UpdateShippingStatusCommand>
{
    private readonly IShippingOrderRepository _repository;

    public UpdateShippingStatusHandler(IShippingOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateShippingStatusCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.OrderId);
        order.UpdateStatus(request.NewStatus);
        await _repository.SaveAsync(order);
        return Unit.Value;
    }
}
