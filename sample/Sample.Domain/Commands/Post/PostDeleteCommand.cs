using Evol.Domain.Commands;
using Sample.Domain.Dto;

namespace Sample.Domain.Commands
{
    public class PostDeleteCommand : Command
    {
        public ItemDeleteDto Input { get; set; }
    }
}
