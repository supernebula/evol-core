using System;
using Evol.Domain.Messaging;

namespace Evol.Domain.Commands
{
    public class Command : ICommand
    {
        public Command()
        {
            Id = Guid.NewGuid();
            Version = "20171110A";
        }

        public string Version { get; private set; }

        public Guid Id { get; private set; }

        //[Obsolete]
        //public List<Event> Events { get; set; }
    }
}
