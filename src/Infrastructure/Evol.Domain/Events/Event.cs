using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.Domain.Messaging;

namespace Evol.Domain.Events
{
    public class Event : IEvent
    {
        public Event()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
