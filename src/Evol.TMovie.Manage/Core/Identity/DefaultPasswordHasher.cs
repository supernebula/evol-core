using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Manage.Models.Identity;
using Evol.Util.Hash;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Core.Identity
{
    public class DefaultPasswordHasher : IPasswordHasher<AppUser>
    {
        private IEmployeeQueryEntry _employeeQueryEntry;
        public DefaultPasswordHasher(IEmployeeQueryEntry employeeQueryEntry)
        {
            _employeeQueryEntry = employeeQueryEntry;
        }
        public string HashPassword(AppUser user, string password)
        {
            var employee = _employeeQueryEntry.FindAsync(user.Id).GetAwaiter().GetResult();
            return HashUtil.Md5PasswordWithSalt(password, employee.Salt);
        }

        //lg-3.
        public PasswordVerificationResult VerifyHashedPassword(AppUser user, string hashedPassword, string providedPassword)
        {
            var employee = _employeeQueryEntry.FindByUsernameAsync(user.Username).GetAwaiter().GetResult();
            var newHashedPassword = HashUtil.Md5PasswordWithSalt(providedPassword, employee.Salt);
            return hashedPassword == newHashedPassword ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}
