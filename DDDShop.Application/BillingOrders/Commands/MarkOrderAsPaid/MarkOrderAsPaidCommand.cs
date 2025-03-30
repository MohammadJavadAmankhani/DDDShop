using MediatR;
using System;

namespace DDDShop.Application.BillingOrders.Commands.MarkOrderAsPaid;

public record MarkOrderAsPaidCommand(Guid OrderId) : IRequest;
