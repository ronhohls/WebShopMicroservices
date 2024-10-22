namespace Ordering.Domain.Abstractions
{
    //generic version of IAggregate to strong-type ID of entities
    public interface IAggregate<T> : IAggregate, IEntity<T>
    {
    }

    public interface IAggregate : IEntity
    {
        //aggregate entities can handle domain events
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
        IDomainEvent[] ClearDomainEvents();
    }
}
