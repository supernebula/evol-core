using Evol.Common;

namespace Evol.TMovie.Domain.Models.AggregateRoots
{
    public class Role : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
