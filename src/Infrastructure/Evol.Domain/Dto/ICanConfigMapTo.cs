using AutoMapper.Configuration;

namespace Evol.Domain.Dto
{
    public interface ICanConfigMapTo<TTo> : ICanConfigMapTo, ICanMapTo<TTo>
    {

    }

    public interface ICanConfigMapTo
    {
        void ConfigMap(MapperConfigurationExpression mapConfig);

    }
}
