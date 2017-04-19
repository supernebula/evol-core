using Evol.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Domain.Messaging
{
    public interface IEventPublisher
    {
        Task PublishAsync(Event @event);

        Task PublishAsync(IEnumerable<Event> @events);
    }
}
