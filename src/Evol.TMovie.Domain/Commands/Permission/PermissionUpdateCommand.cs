using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class PermissionUpdateCommand : Command
    {
        public PermissionCreateOrUpdateDto Input { get; set; }
    }
}
