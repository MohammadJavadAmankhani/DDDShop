using System.Threading.Tasks;
using System;
namespace DDDShop.Domain.Aggregates.BillingOrders.Interfaces;
public interface IBillingOrderRepository
{
    Task AddAsync(BillingOrder order);
    Task<BillingOrder> GetByIdAsync(Guid orderId);
    Task SaveAsync(BillingOrder order);
}
