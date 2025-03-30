using DDDShop.Domain.Aggregates.Orders;
using DDDShop.Domain.Aggregates.Orders.Interfaces;
using DDDShop.Application.Common.Events;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace DDDShop.Infrastructure.Orders;

public class EfOrderRepository : IOrderRepository
{
    private readonly OrdersDbContext _context;
    private readonly IDomainEventDispatcher _dispatcher;

    public EfOrderRepository(OrdersDbContext context, IDomainEventDispatcher dispatcher)
    {
        _context = context;
        _dispatcher = dispatcher;
    }

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await SaveAsync(order);
    }

    public async Task<Order> GetByIdAsync(Guid orderId)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId)
            ?? throw new KeyNotFoundException("Order not found");
    }

    public async Task SaveAsync(Order order)
    {
        await _context.SaveChangesAsync();
        var events = order.GetDomainEvents();
        await _dispatcher.DispatchAsync(events);
        order.ClearDomainEvents();
    }
}
