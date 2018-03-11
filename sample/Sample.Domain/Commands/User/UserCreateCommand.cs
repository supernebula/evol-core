using Evol.Domain.Commands;
using Sample.Domain.Commands.Dto;

namespace Sample.Domain.Commands
{
    public class UserCreateCommand : Command
    {
        public UserCreateDto Input { get; set; }
    }
}
