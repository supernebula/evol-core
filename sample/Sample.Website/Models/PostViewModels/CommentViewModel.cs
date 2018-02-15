using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Sample.Domain.Models.Entities;
using Sample.Domain.Models.Values;
using System;

namespace Sample.Website.Models.PostViewModels
{
    public class CommentViewModel : IOutputDto, ICanConfigMapFrom<Comment>
    {
        public Guid PostId { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public CommentStatus Status { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Comment, CommentViewModel>();
        }
    }
}
