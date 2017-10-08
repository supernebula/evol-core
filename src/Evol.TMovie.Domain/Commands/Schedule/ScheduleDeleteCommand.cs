using Evol.Domain.Commands;
using Evol.TMovie.Domain.Dto;

namespace Evol.TMovie.Domain.Commands
{
    public class ScheduleDeleteCommand : Command
    {
        public ItemDeleteDto Input { get; set; }
    }
}
