using System;
namespace DDDShop.Domain.Aggregates.Orders.Exceptions;
public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
}
