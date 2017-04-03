using System;
using Evol.Domain.Commands;

namespace Evol.Cinema.Domain.Commands
{
    public class MovieDeleteCommand : Command
    {
        public Guid AggregateRootId { get; set; }
    }
}
