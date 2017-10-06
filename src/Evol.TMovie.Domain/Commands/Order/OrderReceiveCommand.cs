using Evol.Domain.Commands;
using Evol.TMovie.Domain.Commands.Dto;

namespace Evol.TMovie.Domain.Commands
{
    public class OrderReceiveCommand : Command
    {
        public OrderReceiveDto Input {get;set;}
    }
}
