using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.EntityFramework.Uow
{
    public static class DbContextExtensions
    {
        public static string GetKey(this DbContext dbContext)
        {
            var key = $"{dbContext.GetType().FullName}_{dbContext.GetHashCode()}";
            return key;
        }
    }
}
