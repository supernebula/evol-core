using Evol.Domain.Commands;
using Evol.TMovie.Domain.Commands.Dto;

namespace Evol.TMovie.Domain.Commands
{
    public class OrderCloseCommand : Command
    {
        public OrderCloseDto Input { get; set; }
    }
}
