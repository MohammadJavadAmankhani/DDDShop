using DDDShop.Domain.Aggregates.Orders;
using DDDShop.Domain.Aggregates.Orders.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace DDDShop.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _repository;

    public CreateOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.CreateDraft(request.CustomerId);
        await _repository.AddAsync(order);
        return order.Id;
    }
}
