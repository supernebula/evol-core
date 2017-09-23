using System;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Repositories;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.Domain.Dto;
using System.Collections.Generic;

namespace Evol.TMovie.Domain.CommandHandlers
{
    public class MovieCommandHandler : 
        ICommandHandler<MovieCreateCommand>, 
        ICommandHandler<MovieUpdateCommand>, 
        ICommandHandler<MovieDeleteCommand>
    {
        public IEventBus EventBus { get; set; }

        public IMovieRepository MovieRepository { get; set; }

        public MovieCommandHandler(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        public async Task ExecuteAsync(MovieCreateCommand command)
        {
            var item = command.Input.Map<Movie>();
            item.Id = Guid.NewGuid();
            item.Title = item.Title ?? string.Empty;
            item.ForeignName = item.ForeignName ?? string.Empty;
            item.ReleaseRegion = item.ReleaseRegion ?? string.Empty;
            item.CoverUri = item.CoverUri ?? string.Empty;
            item.Description = item.Description ?? string.Empty;
            item.Language = item.Language ?? string.Empty;
            item.CreateTime = DateTime.Now;
            await MovieRepository.InsertAsync(item);
        }

        public async Task ExecuteAsync(MovieUpdateCommand command)
        {
            var item = await MovieRepository.FindAsync(command.Input.Id);
            if (item == null)
                throw new KeyNotFoundException();
            var dto = command.Input;
            item.Title = dto.Title ?? string.Empty;
            item.ForeignName = dto.ForeignName ?? string.Empty;
            item.ReleaseDate = dto.ReleaseDate;
            item.Minutes = dto.Minutes;
            item.ReleaseRegion = dto.ReleaseRegion ?? string.Empty;
            item.SpaceType = dto.SpaceType;
            item.Actors = dto.Actors;
            item.CoverUri = dto.CoverUri ?? string.Empty;
            item.Images = dto.Images;
            item.Description = dto.Description ?? string.Empty;
            item.Categorys = dto.Categorys;
            item.Tags = dto.Tags;
            item.Ratings = dto.Ratings;
            item.Language = dto.Language ?? string.Empty;
            await MovieRepository.UpdateAsync(item);
        }

        public async Task ExecuteAsync(MovieDeleteCommand command)
        {
            await MovieRepository.DeleteAsync(command.Input.Id);
        }
    }
}
