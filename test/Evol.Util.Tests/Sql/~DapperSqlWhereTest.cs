//using System;
//using Evol.Util.Sql;
//using System.Diagnostics;
//using Xunit;
//using Evol.Util.Sql.V1;

//namespace Evol.Utilities.Test.Sql
//{
//    public class DapperSqlWhereTest
//    {
//        [Fact]
//        public void SelectSimpleTest()
//        {
//            var param = new { Id = Guid.NewGuid(), Name = "手机" };

//            var sql = SqlWhereBuilder.Create("Select * From [Product]")
//                .And("Id = @Id", "value").Like("Name", "@Name", param.Name)
//                .ToSqlString();
//            Assert.NotNull(sql, "语句为空");
//            Trace.WriteLine(sql);
//        }

//        public void SelectParameterTest()
//        {
            
//        }
//    }
//}
