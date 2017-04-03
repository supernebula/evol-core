using Evol.Cinema.Domain.Commands.Dto;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Domain.Commands;

namespace Evol.Cinema.Domain.Commands
{
    public class MovieCreateCommand : Command
    {
        public MovieCreateDto Input { get; set; }
    }
}
