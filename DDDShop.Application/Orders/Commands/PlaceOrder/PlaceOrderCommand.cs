using MediatR;
using System;

namespace DDDShop.Application.Orders.Commands.PlaceOrder;

public record PlaceOrderCommand(Guid OrderId) : IRequest;
