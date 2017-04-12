using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class CinemaUpdateCommand : Command
    {
        public CinemaCreateOrUpdateDto Input { get; set; }
    }
}
