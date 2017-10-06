using Evol.Domain.Commands;
using Evol.TMovie.Domain.Commands.Dto;

namespace Evol.TMovie.Domain.Commands
{
    public class OrderCompleteCommand : Command
    {
        public OrderCompleteDto Input { get; set; }
    }
}
