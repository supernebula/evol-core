using Evol.Domain.Commands;
using Sample.Domain.Commands.Dto;

namespace Sample.Domain.Commands
{
    public class PostCreateCommand : Command
    {
        public PostCreateDto Input { get; set; }
    }
}
