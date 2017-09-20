using System;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Repositories;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.Domain.Events;
using Evol.Domain.Dto;
using System.Collections.Generic;
using Evol.TMovie.Domain.Events;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class MovieCommandHandler : ICommandHandler<MovieCreateCommand>, ICommandHandler<MovieUpdateCommand>, ICommandHandler<MovieDeleteCommand>
    {
        public IEventPublisher EventPub { get; set; }

        public IMovieRepository MovieRepository { get; set; }

        public MovieCommandHandler(IMovieRepository movieRepository, IEventPublisher eventPublisher)
        {
            MovieRepository = movieRepository;
            EventPub = eventPublisher;
        }

        public async Task ExecuteAsync(MovieCreateCommand command)
        {
            var item = command.Input.Map<Movie>();
            item.Id = Guid.NewGuid();
            item.Title = item.Title ?? string.Empty;
            //....更多字段
            item.CreateTime = DateTime.Now;
            await MovieRepository.InsertAsync(item);
            //await EventPub.PublishAsync(new OrderCreateEvent()); //test
            //command.Events.Add(new Event(item));
        }

        public async Task ExecuteAsync(MovieUpdateCommand command)
        {
            var item = await MovieRepository.FindAsync(command.Input.Id);
            if (item == null)
                throw new KeyNotFoundException();
            item.Title = command.Input.Title;
            //....更多字段
            MovieRepository.Update(item);
        }

        public Task ExecuteAsync(MovieDeleteCommand command)
        {
            MovieRepository.Delete(command.Input.Id);
            return Task.FromResult(1);
        }
    }
}
