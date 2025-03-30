using System;

namespace DDDShop.API.DTOs;

public record AddItemToOrderDto
{
    public Guid ProductId { get; init; }
    public string Name { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}
