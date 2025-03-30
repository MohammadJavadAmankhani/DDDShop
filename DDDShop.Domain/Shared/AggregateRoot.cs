using System.Collections.Generic;
using DDDShop.Domain.Shared;

namespace DDDShop.Domain.Shared;
public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected void RaiseDomainEvent(IDomainEvent @event)
    {
        _domainEvents.Add(@event);
    }

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

    public void ClearDomainEvents() => _domainEvents.Clear();
}
