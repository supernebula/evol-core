using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class SeatChangeCommand : Command
    {
        public SeatChangeDto Input { get; set; }
    }
}
