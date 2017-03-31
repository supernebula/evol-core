using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Domain.Commands;

namespace Evol.Cinema.Domain.Commands
{
    public class MovieCreateCommand : Command
    {
        public Movie AggregateRoot { get; set; }
    }
}
