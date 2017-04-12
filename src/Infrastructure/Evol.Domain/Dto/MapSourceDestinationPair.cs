using System;

namespace Evol.Domain.Dto
{
    /// <summary>
    /// object-object mapper
    /// </summary>
    public class MapSourceDestinationPair
    {
        public Type Source { get; set; }

        public Type Destination { get; set; }
    }
}
