using System;
using Evol.Domain.Messaging;

namespace Evol.Domain.Commands
{
    public class Command : ICommand
    {
        public Command()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
