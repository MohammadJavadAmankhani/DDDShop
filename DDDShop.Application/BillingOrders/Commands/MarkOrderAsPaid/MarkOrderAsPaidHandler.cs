using DDDShop.Domain.Aggregates.BillingOrders;
using DDDShop.Domain.Aggregates.BillingOrders.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace DDDShop.Application.BillingOrders.Commands.MarkOrderAsPaid;

public class MarkOrderAsPaidHandler : IRequestHandler<MarkOrderAsPaidCommand>
{
    private readonly IBillingOrderRepository _repository;

    public MarkOrderAsPaidHandler(IBillingOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(MarkOrderAsPaidCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.OrderId);
        order.MarkAsPaid();
        await _repository.SaveAsync(order);
        return Unit.Value;
    }
}
