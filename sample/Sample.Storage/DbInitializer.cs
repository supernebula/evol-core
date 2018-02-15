using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sample.Storage
{
    public class DbInitializer
    {
        public async Task InitializeAsync(EvolSampleDbContext context)
        {
            var migrations = await context.Database.GetPendingMigrationsAsync();//获取未应用的Migrations，不必要，MigrateAsync方法会自动处理
            await context.Database.MigrateAsync();//根据Migrations修改/创建数据库
        }
    }
}
