using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class EmployeeCreateCommand : Command
    {
        public EmployeeCreateOrUpdateDto Input { get; set; }
    }
}
