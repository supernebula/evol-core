using Evol.Domain.Events;
using System;
using System.Collections.Generic;

namespace Evol.Domain.Messaging
{
    public interface ICommand
    {
        Guid Id { get; }

        string Version { get;}

        //[Obsolete]
        //List<Event> Events { get; set; }
    }
}
