using System;

namespace Evol.Domain.Messaging
{
    public interface IEvent
    {
        Guid Id { get;}
    }
}
