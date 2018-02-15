using Evol.Domain.Commands;
using Sample.Domain.Commands.Dto;

namespace Sample.Domain.Commands
{
    public class CommentCreateCommand : Command
    {
        public CommentCreateDto Input { get; set; }
    }
}
