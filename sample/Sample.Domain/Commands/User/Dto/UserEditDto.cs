using Evol.Domain.Dto;
using System;

namespace Sample.Domain.Commands.Dto
{
    public class UserEditDto : IInputDto
    {
        public Guid Id { get; set; }

        public string Nick { get; set; }

        public string AvatarPath { get; set; }
    }
}
