using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class CinemaCreateCommand : Command
    {
        public CinemaCreateDto Input { get; set; }
    }
}
