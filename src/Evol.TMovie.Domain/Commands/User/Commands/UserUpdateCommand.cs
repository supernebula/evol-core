using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class UserUpdateCommand : Command
    {
        public UserUpdateDto Input { get; set; }
    }
}
