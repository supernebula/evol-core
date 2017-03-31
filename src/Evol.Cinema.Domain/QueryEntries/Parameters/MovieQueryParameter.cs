using System;
using Evol.Cinema.Domain.Models.Values;

namespace Evol.Cinema.Domain.QueryEntries.Parameters
{
    public class MovieQueryParameter
    {
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string ReleaseRegion { get; set; }

        public SpaceDimensionType? SpaceType { get; set; }

        public string Language { get; set; }
    }
}
