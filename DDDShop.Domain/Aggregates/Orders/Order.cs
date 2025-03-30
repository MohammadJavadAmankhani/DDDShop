using System.Collections.Generic;
using System;
using DDDShop.Domain.Shared;
using DDDShop.Domain.Aggregates.Orders.Entities;
using DDDShop.Domain.Aggregates.Orders.Enums;
using DDDShop.Domain.Aggregates.Orders.ValueObjects;
using DDDShop.Domain.Aggregates.Orders.Exceptions;
using DDDShop.Domain.Aggregates.Orders.Events;

namespace DDDShop.Domain.Aggregates.Orders;
public class Order : AggregateRoot
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();
    public Address? ShippingAddress { get; private set; }

    private Order() { }

    public static Order CreateDraft(Guid customerId)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Status = OrderStatus.Draft
        };
    }

    public void AddItem(Guid productId, string name, decimal price, int quantity)
    {
        EnsureDraft();

        var existing = Items.FirstOrDefault(x => x.ProductId == productId);
        if (existing != null)
            existing.IncreaseQuantity(quantity);
        else
            Items.Add(new OrderItem(productId, name, price, quantity));
    }

    public void ChangeAddress(Address address)
    {
        EnsureDraft();
        ShippingAddress = address;
    }

    public void PlaceOrder()
    {
        EnsureDraft();

        if (!Items.Any())
            throw new DomainException("Order must have at least one item.");

        if (ShippingAddress == null)
            throw new DomainException("Shipping address is required.");

        Status = OrderStatus.Placed;

        RaiseDomainEvent(new OrderPlaced(Id, CustomerId, DateTime.UtcNow));
    }

    private void EnsureDraft()
    {
        if (Status != OrderStatus.Draft)
            throw new DomainException("Only draft orders can be modified.");
    }
}
