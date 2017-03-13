using Evol.Util.Sql;
using System.Diagnostics;
using Xunit;

namespace Evol.Utilities.Test.Sql
{
    public class SqlBuilderTest
    {
        [Fact]
        public void SimpleSqlTest()
        {
        //    var sqlWhereBuilder = SqlWhereBuilder.Create("Select * From Product")
        //        .And("Name Like '%' + {0} + '%'", "@Name", "手机")
        //        .And("Price > {0}", "@Price", 1300)
        //        .AndExpression(s => s.And("Site = {0}", "@Site", "jd.com").Or("Site = {0}", "@Site", "taoba.com"));
                

        //    var sql = sqlWhereBuilder.ToSqlString();
        //    Trace.WriteLine(sql);
        //    var sqlParam = sqlWhereBuilder.ToSqlParameters();
        //    Trace.WriteLine(sqlParam.Count);
        }
    }
}
