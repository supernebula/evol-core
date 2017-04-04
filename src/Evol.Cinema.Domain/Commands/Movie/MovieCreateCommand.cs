using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class MovieCreateCommand : Command
    {
        public MovieCreateDto Input { get; set; }
    }
}
