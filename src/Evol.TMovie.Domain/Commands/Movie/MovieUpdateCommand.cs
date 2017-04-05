using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class MovieUpdateCommand : Command
    {
        public Movie AggregateRoot { get; set; }
    }
}
