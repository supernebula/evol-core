using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Sample.Domain.Models.Entities;

namespace Sample.Domain.Commands.Dto
{
    public class CommentCreateDto : IInputDto, ICanConfigMapTo<Comment>
    {
        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<PostCreateDto, Comment>();
        }
    }
}
