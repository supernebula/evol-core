using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Models
{
    public class RoleViewModel : IOutputDto, ICanMapFrom<Role>
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
