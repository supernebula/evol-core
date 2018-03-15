using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Sample.Domain.Models.AggregateRoots;
using System;

namespace Sample.Website.Models.PostViewModels
{
    public class PostViewModel : IOutputDto, ICanConfigMapFrom<Post>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Tag { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreateTime { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Post, PostViewModel>();
        }
    }
}
