using Evol.Domain.Events;
using System.Threading.Tasks;

namespace Evol.Domain.Messaging
{
    public class EventBus : IEventBus
    {
        public IEventHandlerFactory _eventHandlerFactory { get; set; }

        public EventBus(IEventHandlerFactory eventHandlerFactory)
        {
            _eventHandlerFactory = eventHandlerFactory;
        }
        
        public async Task PublishAsync<T>(T @event) where T : Event
        {
            var handlers = _eventHandlerFactory.GetHandler<T>();
            foreach (var handler in handlers)
            {
                await handler.HandleAsync(@event);
            }
        }
    }
}
