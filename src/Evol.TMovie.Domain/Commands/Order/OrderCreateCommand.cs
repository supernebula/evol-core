using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class OrderCreateCommand : Command
    {
        public OrderCreateDto Input { get; set; }
    }
}
