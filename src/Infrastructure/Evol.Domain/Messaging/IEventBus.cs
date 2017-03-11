using Evol.Domain.Events;

namespace Evol.Domain.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }
}
