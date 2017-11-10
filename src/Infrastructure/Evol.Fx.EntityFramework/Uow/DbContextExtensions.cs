using System.Data.Entity;

namespace Evol.Fx.EntityFramework.Uow
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
