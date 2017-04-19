using System;
using Evol.Domain.Messaging;
using Evol.Common;
using Evol.Domain.Events;
using System.Collections.Generic;

namespace Evol.Domain.Commands
{
    public class Command : ICommand
    {
        public Command()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public List<Event> Events { get; set; }
    }
}
