using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class ScreeningRoomCreateCommand : Command
    {
        public ScreeningRoomCreateDto Input { get; set; }
    }
}
