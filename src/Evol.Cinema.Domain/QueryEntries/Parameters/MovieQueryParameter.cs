using System;
using Evol.TMovie.Domain.Models.Values;

namespace Evol.TMovie.Domain.QueryEntries.Parameters
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
