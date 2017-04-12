using AutoMapper;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;

namespace Evol.TMovie.Manage.Models
{
    public class CinemaViewModel : IOutputDto, ICanMapFrom<Cinema>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
