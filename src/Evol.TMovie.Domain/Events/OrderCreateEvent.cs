using Evol.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Evol.Domain.Models;

namespace Evol.TMovie.Domain.Events
{
    public class OrderCreateEvent : Event
    {
        public OrderCreateEvent(IAggregateRoot aggregateRoot) : base(aggregateRoot)
        {
        }
    }
}
