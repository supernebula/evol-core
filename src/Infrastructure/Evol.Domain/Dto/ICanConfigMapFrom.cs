using AutoMapper.Configuration;
using Evol.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Domain.Dto
{

    public interface ICanConfigMapFrom<TTo> : ICanConfigMapFrom, ICanMapFrom<TTo>
    {
    }

    public interface ICanConfigMapFrom
    {
        void ConfigMap(MapperConfigurationExpression mapConfig);

    }
}
