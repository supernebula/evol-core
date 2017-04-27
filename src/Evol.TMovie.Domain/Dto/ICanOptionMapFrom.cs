using AutoMapper.Configuration;
using Evol.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Dto
{

    public interface ICanOptionMapFrom<TTo> : ICanOptionMapFrom, ICanMapFrom<TTo>
    {
    }

    public interface ICanOptionMapFrom
    {
        void ConfigMap(MapperConfigurationExpression mapConfig);

    }
}
