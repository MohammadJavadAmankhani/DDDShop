using DDDShop.Domain.Aggregates.BillingOrders;
using DDDShop.Domain.Aggregates.BillingOrders.Interfaces;
using DDDShop.Application.Common.Events;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DDDShop.Infrastructure.Orders;

namespace DDDShop.Infrastructure.BillingOrders;

public class EfBillingOrderRepository : IBillingOrderRepository
{
    private readonly OrdersDbContext _context;
    private readonly IDomainEventDispatcher _dispatcher;

    public EfBillingOrderRepository(OrdersDbContext context, IDomainEventDispatcher dispatcher)
    {
        _context = context;
        _dispatcher = dispatcher;
    }

    public async Task AddAsync(BillingOrder order)
    {
        _context.Set<BillingOrder>().Add(order);
        await SaveAsync(order);
    }

    public async Task<BillingOrder> GetByIdAsync(Guid id)
    {
        return await _context.Set<BillingOrder>().FindAsync(id)
            ?? throw new KeyNotFoundException("Billing order not found");
    }

    public async Task SaveAsync(BillingOrder order)
    {
        await _context.SaveChangesAsync();
        var events = order.GetDomainEvents();
        await _dispatcher.DispatchAsync(events);
        order.ClearDomainEvents();
    }
}
