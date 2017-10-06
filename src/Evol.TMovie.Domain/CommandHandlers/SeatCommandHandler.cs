using Evol.Domain.Dto;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
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

        public SeatCommandHandler(ISeatRepository seatRepository, ISeatQueryEntry seatQueryEntry)
        {
            SeatRepository = seatRepository;
            SeatQueryEntry = seatQueryEntry;
        }
        public async Task ExecuteAsync(SeatChangeCommand command)
        {
            var newSeats = command.Input.Seats.MapList<Seat>();

            var seats = await SeatQueryEntry.SelectAsync(new SeatQueryParameter() { ScreeningRoomId = command.Input.ScreeningRoomId });
            await SeatRepository.DeleteAsync(seats);

            foreach (var newSeat in newSeats)
            {
                await SeatRepository.InsertAsync(newSeat);
            }

        }
    }
}
