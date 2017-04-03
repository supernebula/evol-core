using Evol.Cinema.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.Cinema.Domain.Commands
{
    public class CinemaDeleteCommand : Command
    {
        public CinemaDeleteDto Input { get; set; }
    }
}
