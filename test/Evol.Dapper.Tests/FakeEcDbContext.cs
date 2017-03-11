
namespace Evol.Dapper.Repository.Test
{
    public class FakeEcDbContext : DapperDbContext
    {
        public FakeEcDbContext() : base("fakeEcConnectionString")
        {
        }
    }
}
