using Evol.Domain.Commands;
using Sample.Domain.Commands.Dto;

namespace Sample.Domain.Commands
{
    public class UserChangePasswordCommand : Command
    {
        public UserChangePasswordDto Input { get; set; }
    }
}
