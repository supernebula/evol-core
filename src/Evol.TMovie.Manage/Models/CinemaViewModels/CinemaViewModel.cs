using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;

namespace Evol.TMovie.Manage.Models
{
    public class CinemaViewModel : IOutputDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime CreateTime { get; set; }

        public static CinemaViewModel From(Cinema value)
        {
            return new CinemaViewModel()
            {
                Id = value.Id,
                Name = value.Name,
                Address = value.Address,
                CreateTime = value.CreateTime
            };
        }
    }
}
