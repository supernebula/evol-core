using System.Collections.Generic;
using System.Linq;
using Evol.Test.Model;

namespace Evol.Dapper.Repository.Test
{
    public class FakeUserRepository : BasicDapperRepository<FakeUser, FakeEcDbContext>
    {
        public FakeUserRepository(IDbConnectionFactory<FakeEcDbContext> dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public List<FakeUser> Take(int num = 0)
        {
            string sql = null;
            if (num <= 0)
                sql = "SELECT * FROM [FakeUser]";
            else
                sql = "SELECT TOP " + num + " * FROM [FakeUser]";
            return this.Query(sql).ToList();
        }
    }
}
