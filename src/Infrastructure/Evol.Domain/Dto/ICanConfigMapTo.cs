using AutoMapper.Configuration;

namespace Evol.Domain.Dto
{
    /// <summary>
    /// Automapper 对象配置接口
    /// <see cref="Evol.Domain.Dto.DtoEntityMapInitiator"/>
    /// </summary>
    /// <typeparam name="TTo"></typeparam>
    public interface ICanConfigMapTo<TTo> : ICanConfigMapTo, ICanMapTo<TTo>
    {

    }

    public interface ICanConfigMapTo
    {
        void ConfigMap(MapperConfigurationExpression mapConfig);

    }
}
