using MediatR;
using System;

namespace DDDShop.Application.Orders.Commands.ChangeShippingAddress;

public record ChangeShippingAddressCommand(Guid OrderId, string Street, string City, string PostalCode, string Country) : IRequest;
