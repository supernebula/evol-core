using Evol.Domain.Commands;
using Evol.TMovie.Domain.Dto;

namespace Evol.TMovie.Domain.Commands
{
    public class ScreeningDeleteCommand : Command
    {
        public ItemDeleteDto Input { get; set; }
    }
}
