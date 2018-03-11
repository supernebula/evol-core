using Evol.Domain.Commands;
using Sample.Domain.Commands.Dto;

namespace Sample.Domain.Commands
{
    public class UserEditCommand : Command
    {
        public UserEditDto Input { get; set; }
    }
}
