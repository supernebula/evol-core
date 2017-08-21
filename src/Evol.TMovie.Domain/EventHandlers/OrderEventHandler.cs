using Evol.Domain.Events;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.EventHandlers
{
    class OrderEventHandler : IEventHandler<OrderCreateEvent>
    {
        [HandleAsync]
        public Task HandleAsync(OrderCreateEvent @event)
        {
            //Send SMS
            throw new NotImplementedException();
        }
    }
}
