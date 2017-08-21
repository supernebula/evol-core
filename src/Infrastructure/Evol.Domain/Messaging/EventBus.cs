using Evol.Domain.Events;
using System;
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
                var method = handler.GetType().GetMethod(nameof(handler.HandleAsync));
                var handleAsync = Attribute.GetCustomAttribute(method, typeof(HandleAsyncAttribute), false) as HandleAsyncAttribute;
                if (handleAsync != null)
                    AsyncInvoke(() => handler.HandleAsync(@event));
                else
                    await handler.HandleAsync(@event);
            }
        }

        private void AsyncInvoke(Action action)
        {
            throw new NotImplementedException();
            Task.Run(action)
                .ContinueWith(t => {
                    //if(t.Exception != null)
                        //some logic & logger
                });
        }
    }
}
