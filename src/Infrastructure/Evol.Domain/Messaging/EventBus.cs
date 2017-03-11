using Evol.Domain.Events;

namespace Evol.Domain.Messaging
{
    public class EventBus : IEventBus
    {
        public IEventHandlerFactory EventHandlerFactory { get; set; }
        public void Publish<T>(T @event) where T : Event
        {
            var handlers = EventHandlerFactory.GetHandler<T>();
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
