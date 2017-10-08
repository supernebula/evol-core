using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class ScheduleCreateCommand : Command
    {
        public ScheduleCreateDto Input { get; set; }
    }
}
