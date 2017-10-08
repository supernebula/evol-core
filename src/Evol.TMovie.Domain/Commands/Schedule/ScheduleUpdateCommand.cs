using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class ScheduleUpdateCommand : Command
    {
        public ScheduleUpdateDto Input { get; set; }
    }
}
