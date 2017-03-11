using Evol.Domain.Events;

namespace Evol.Domain.Messaging
{
    public interface IEventHandler<in T> where T : Event
    {
        void Handle(T @event);
    }
}
