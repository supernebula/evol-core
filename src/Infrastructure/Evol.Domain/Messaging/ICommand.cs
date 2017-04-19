using Evol.Domain.Events;
using System;
using System.Collections.Generic;

namespace Evol.Domain.Messaging
{
    public interface ICommand
    {
        Guid Id { get; }

        List<Event> Events { get; set; }
    }
}
