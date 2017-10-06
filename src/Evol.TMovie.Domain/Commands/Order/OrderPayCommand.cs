using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Commands;

namespace Evol.TMovie.Domain.Commands
{
    public class OrderPayCommand : Command
    {
        public OrderPayDto Input { get; set; }
    }
}
