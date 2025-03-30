using System.Threading.Tasks;
using System;
namespace DDDShop.Domain.Aggregates.ShippingOrders.Interfaces;
public interface IShippingOrderRepository
{
    Task AddAsync(ShippingOrder order);
    Task<ShippingOrder> GetByIdAsync(Guid orderId);
    Task SaveAsync(ShippingOrder order);
}
