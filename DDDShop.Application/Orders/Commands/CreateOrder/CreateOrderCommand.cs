using MediatR;
using System;

namespace DDDShop.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid CustomerId) : IRequest<Guid>;
