using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.Util.Hash;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Core.Identity
{
    public class DefaultPasswordHasher : IPasswordHasher<HashUser>
    {
        public string HashPassword(HashUser user, string password)
        {
            return HashUtil.Md5PasswordWithSalt(password, user.Salt);
        }

        public PasswordVerificationResult VerifyHashedPassword(HashUser user, string hashedPassword, string providedPassword)
        {
            var newHashedPassword = HashUtil.Md5PasswordWithSalt(providedPassword, user.Salt);
            return hashedPassword == newHashedPassword ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}
