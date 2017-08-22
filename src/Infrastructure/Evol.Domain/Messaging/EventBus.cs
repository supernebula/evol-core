using Evol.Domain.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Evol.Domain.Messaging
{
    public class EventBus : IEventBus
    {
        public IEventHandlerFactory _eventHandlerFactory { get; set; }

        public ILogger _logger { get; set; }

        public EventBus(IEventHandlerFactory eventHandlerFactory, ILogger logger)
        {
            _eventHandlerFactory = eventHandlerFactory;
            _logger = logger;
        }
        
        public async Task PublishAsync<T>(T @event) where T : Event
        {
            var handlers = _eventHandlerFactory.GetHandler<T>();
            foreach (var handler in handlers)
            {
                var method = handler.GetType().GetMethod(nameof(handler.HandleAsync));
                var handleAsync = Attribute.GetCustomAttribute(method, typeof(HandleAsyncAttribute), false) as HandleAsyncAttribute;
                if (handleAsync != null)
                    AsyncHandle(() => handler.HandleAsync(@event));
                else
                    await handler.HandleAsync(@event);
            }
        }

        private void AsyncHandle(Action action)
        {
            var cancelSource = new CancellationTokenSource();
            Task.Run(action, cancelSource.Token)
                .ContinueWith(t => {
                    if (t.Exception == null)
                        return;
                    _logger.LogError(t.Exception, "在处理HandleAsyncAttribute标记的异步逻辑时发生异常");
                });
        }
    }
}
