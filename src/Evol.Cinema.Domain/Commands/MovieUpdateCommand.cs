using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Domain.Commands;

namespace Evol.Cinema.Domain.Commands
{
    public class MovieUpdateCommand : Command
    {
        public Movie AggregateRoot { get; set; }
    }
}
