using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.Domain.Commands;
using Evol.TMovie.Domain.Commands.Dto;

namespace Evol.TMovie.Domain.Commands
{
    public class MovieUpdateCommand : Command
    {
        public MovieCreateOrUpdateDto Input { get; set; }
    }
}
