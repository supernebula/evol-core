using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;

namespace Evol.TMovie.Manage.Models
{
    public class PermissonViewModel : IOutputDto, ICanMapFrom<Permission>
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
