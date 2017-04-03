using Evol.Cinema.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.Cinema.Domain.Commands
{
    public class CinemaCreateCommand : Command
    {
        public CinemaCreateDto Input { get; set; }
    }
}
