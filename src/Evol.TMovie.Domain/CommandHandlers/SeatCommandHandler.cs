using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class SeatCommandHandler :
        ICommandHandler<SeatChangeCommand>
    {
        public ISeatRepository SeatRepository { get; private set; }

        public ISeatQueryEntry SeatQueryEntry { get; private set; }

        public SeatCommandHandler(ISeatRepository seatRepository)
        {
            SeatRepository = seatRepository;
        }
        public Task ExecuteAsync(SeatChangeCommand command)
        {
            
            throw new NotImplementedException();
        }
    }
}
