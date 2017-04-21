using Evol.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Services.Models
{
    public class EmployeePermissionDto : IOutputDto
    {
        public Guid EmployeeId { get; set; }

        public string UserName { get; set; }

        public string RealName { get; set; }

        public List<KeyValuePair<Guid, string>> Roles { get; set; }

        public List<KeyValuePair<Guid, string>> CustomPermissions { get; set; }
    }
}
