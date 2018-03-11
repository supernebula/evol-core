using Evol.Domain.Dto;
using System;

namespace Sample.Domain.Commands.Dto
{
    public class UserChangePasswordDto : IInputDto
    {
        public Guid Id { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
