using ConfigsDomain.Primitives;

namespace ConfigsApplication.Abstracts;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
{
}
