using DDDShop.Domain.Aggregates.ShippingOrders.Enums;
using MediatR;
using System;

namespace DDDShop.Application.ShippingOrders.Commands.UpdateShippingStatus;

public record UpdateShippingStatusCommand(Guid OrderId, ShippingStatus NewStatus) : IRequest;
