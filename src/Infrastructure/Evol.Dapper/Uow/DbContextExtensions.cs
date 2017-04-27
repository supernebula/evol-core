
namespace Evol.Dapper.Uow
{
    public static class DbContextExtensions
    {
        public static string GetKey(this DapperDbContext dbContext)
        {
            var key = $"{dbContext.DbContext.FullName}_{dbContext.GetHashCode()}";
            return key;
        }
    }
}
