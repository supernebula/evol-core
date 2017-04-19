using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Evol.Domain.Events;

namespace Evol.Domain.Messaging
{
    public class EventPublisher : IEventPublisher
    {
        private IEventBus _eventBus { get; set; }

        public EventPublisher(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task PublishAsync(Event @event)
        {
            await _eventBus.PublishAsync(@event);
        }

        public async Task PublishAsync(IEnumerable<Event> @events)
        {
            foreach (var @event in @events)
            {
                await PublishAsync(@event);
            }
        }
    }
}
