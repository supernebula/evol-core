using Evol.Domain.Commands;
using Evol.TMovie.Domain.Commands.Dto;

namespace Evol.TMovie.Domain.Commands
{
    public class UserCreateCommand : Command
    {
        public UserCreateDto Input { get; set; }
    }
}
