using AutoMapper;
using Evol.Domain.Dto;

namespace Evol.TMovie.Domain.Dto
{
    /// <summary>
    /// Object-object mapping
    /// </summary>
    public static class IObjectMapExtensions
    {
        public static TTo Map<TTo>(this object source)
        {
            return Mapper.Map<TTo>(source);
        }
    }
}
