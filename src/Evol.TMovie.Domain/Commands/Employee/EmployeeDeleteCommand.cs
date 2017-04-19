using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;
using Evol.TMovie.Domain.Dto;

namespace Evol.TMovie.Domain.Commands
{
    public class EmployeeDeleteCommand : Command
    {
        public ItemDeleteDto Input { get; set; }
    }
}
