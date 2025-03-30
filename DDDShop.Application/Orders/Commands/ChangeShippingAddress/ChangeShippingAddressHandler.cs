using DDDShop.Domain.Aggregates.Orders.Interfaces;
using DDDShop.Domain.Aggregates.Orders;
using DDDShop.Domain.Aggregates.Orders.ValueObjects;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace DDDShop.Application.Orders.Commands.ChangeShippingAddress;

public class ChangeShippingAddressHandler : IRequestHandler<ChangeShippingAddressCommand>
{
    private readonly IOrderRepository _repository;

    public ChangeShippingAddressHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(ChangeShippingAddressCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.OrderId);
        var address = new Address(request.Street, request.City, request.PostalCode, request.Country);
        order.ChangeAddress(address);
        await _repository.SaveAsync(order);
        return Unit.Value;
    }
}
