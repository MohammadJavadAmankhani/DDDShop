using System.Collections.Generic;
using System.Threading.Tasks;
using DDDShop.Domain.Shared;
namespace DDDShop.Application.Common.Events;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents);
}
