using System;
namespace DDDShop.Domain.Aggregates.Orders.Entities;
public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ProductId { get; private set; }
    public string Name { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem(Guid productId, string name, decimal unitPrice, int quantity)
    {
        ProductId = productId;
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int amount)
    {
        Quantity += amount;
    }
}
