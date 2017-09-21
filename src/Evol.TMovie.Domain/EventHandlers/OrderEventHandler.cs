using Evol.Domain.Events;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.EventHandlers
{
    public class OrderEventHandler : IEventHandler<OrderCreateEvent>
    {
        [ForkHandle]
        public Task HandleAsync(OrderCreateEvent @event)
        {
            //Send SMS
            throw new NotImplementedException();
        }
    }
}
