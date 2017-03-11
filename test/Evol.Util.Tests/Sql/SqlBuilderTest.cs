using Evol.Utilities.Sql;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evol.Utilities.Test.Sql
{
    [TestClass]
    public class SqlBuilderTest
    {
        [TestMethod]
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
