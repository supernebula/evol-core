using Evol.Domain.Dto;
using System;

namespace Evol.TMovie.Manage.Models
{
    public class CinemaViewModel : IOutputDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
