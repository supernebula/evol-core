using AutoMapper.Configuration;
using Evol.Domain.Dto;

namespace Evol.TMovie.Domain.Dto
{
    public interface ICanOptionMapTo<TTo> : ICanOptionMapTo, ICanMapTo<TTo>
    {

    }

    public interface ICanOptionMapTo
    {
        void ConfigMap(MapperConfigurationExpression mapConfig);

    }
}
