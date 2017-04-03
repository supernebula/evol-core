using Evol.Cinema.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.Cinema.Domain.Commands
{
    public class CinemaUpdateCommand : Command
    {
        public CinemaUpdateDto Input { get; set; }
    }
}
