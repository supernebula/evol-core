using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
