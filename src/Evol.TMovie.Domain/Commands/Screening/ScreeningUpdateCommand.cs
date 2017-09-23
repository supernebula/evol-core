using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class ScreeningUpdateCommand : Command
    {
        public ScreeningUpdateDto Input { get; set; }
    }
}
