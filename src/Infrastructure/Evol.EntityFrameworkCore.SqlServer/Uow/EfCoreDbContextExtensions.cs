using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFrameworkCore.SqlServer.Uow
{
    public static class EfCoreDbContextExtensions
    {
        public static string GetKey(this DbContext dbContext)
        {
            var key = $"{dbContext.GetType().FullName}_{dbContext.GetHashCode()}";
            return key;
        }
    }
}
