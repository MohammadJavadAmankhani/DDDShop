using DDDShop.Domain.Aggregates.ShippingOrders;
using DDDShop.Domain.Aggregates.ShippingOrders.Interfaces;
using DDDShop.Application.Common.Events;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DDDShop.Infrastructure.Orders;

namespace DDDShop.Infrastructure.ShippingOrders;

public class EfShippingOrderRepository : IShippingOrderRepository
{
    private readonly OrdersDbContext _context;
    private readonly IDomainEventDispatcher _dispatcher;

    public EfShippingOrderRepository(OrdersDbContext context, IDomainEventDispatcher dispatcher)
    {
        _context = context;
        _dispatcher = dispatcher;
    }

    public async Task AddAsync(ShippingOrder order)
    {
        _context.Set<ShippingOrder>().Add(order);
        await SaveAsync(order);
    }

    public async Task<ShippingOrder> GetByIdAsync(Guid id)
    {
        return await _context.Set<ShippingOrder>().FindAsync(id)
            ?? throw new KeyNotFoundException("Shipping order not found");
    }

    public async Task SaveAsync(ShippingOrder order)
    {
        await _context.SaveChangesAsync();
        var events = order.GetDomainEvents();
        await _dispatcher.DispatchAsync(events);
        order.ClearDomainEvents();
    }
}
