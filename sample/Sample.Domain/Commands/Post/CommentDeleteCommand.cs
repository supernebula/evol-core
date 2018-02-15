using Evol.Domain.Commands;
using Sample.Domain.Dto;

namespace Sample.Domain.Commands
{
    public class CommentDeleteCommand : Command
    {
        public ItemDeleteDto Input { get; set; }
    }
}
