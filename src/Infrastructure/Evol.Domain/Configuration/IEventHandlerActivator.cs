using System.Collections.Generic;
using Evol.Domain.Events;
using Evol.Domain.Messaging;

namespace Evol.Domain.Configuration
{
    public interface IEventHandlerActivator
    {
        IEnumerable<IEventHandler<T>> Create<T>() where T : Event;
    }
}
