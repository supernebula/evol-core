using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class CinemaUpdateCommand : Command
    {
        public CinemaUpdateDto Input { get; set; }
    }
}
