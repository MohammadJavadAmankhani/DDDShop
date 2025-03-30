using System.Threading.Tasks;
using System;
namespace DDDShop.Domain.Aggregates.Orders.Interfaces;
public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<Order> GetByIdAsync(Guid orderId);
    Task SaveAsync(Order order);
}
