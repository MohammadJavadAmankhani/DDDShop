using MediatR;
using System;

namespace DDDShop.Application.Orders.Commands.AddItemToOrder;

public record AddItemToOrderCommand(Guid OrderId, Guid ProductId, string Name, decimal UnitPrice, int Quantity) : IRequest;
