using System.Collections.Generic;
using Evol.Domain.Events;

namespace Evol.Domain.Messaging
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandler<T>() where T : Event;
    }
}
