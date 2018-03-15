using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Sample.Domain.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Domain.Commands.Dto
{
    public class CommentCreateDto : IInputDto, ICanConfigMapTo<Comment>
    {

        public Guid PostId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Content { get; set; }

        //public Guid UserId { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<CommentCreateDto, Comment>();
        }
    }
}
