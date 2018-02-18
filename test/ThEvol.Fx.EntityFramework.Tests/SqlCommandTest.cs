using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
using Xunit;
using Evol.Fx.EntityFramework.Repository.Test.Core;
using Evol.Test.Models;
using Evol.Util.Sql;

namespace Evol.Fx.EntityFramework.Repository.Test
{
    public class SqlCommandTest
    {
        [Fact]
        public void SqlQueryEntitiesTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var users = context.Set<FakeUser>().SqlQuery("SELECT * TOP 10 FROM [FakeUser]").ToList();
                var users2 = context.Set<FakeUser>().SqlQuery("SELECT * TOP 10 FROM [FakeUser] WHERE [Username] = @username", new SqlParameter("@username", "zhangsan")).ToList();
            }
        }

        [Fact]
        public void StoredProceduleTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var users = context.Set<FakeUser>().SqlQuery("dbo.GetUsers").ToList();
                var userId = 1;
                //带参数的存储过程
                var users2 = context.Set<FakeUser>().SqlQuery("dbo.GetUsers @p0", userId).ToList();
            }
        }

        [Obsolete("未实现。。。")]
        public void SqlQueriesForNoEntityTypeTest()
        {
            using (var context = new FakeEcDbContext())
            {
                //var users = context.Database.FromSql<string>("SELECT [Name] FROM [FakeUser] WHERE [Id] = @id",new SqlParameter("@id", 1)).FirstOrDefault();
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void SqlCommandInsertTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var num = context.Database.ExecuteSqlCommand("INSERT INTO [FakeUser]([Id], [Username], [Password], [Address], [Mobile], [Email], [Points], [MarkDelete], [CreateDate]) VALUES(@username, @password, @address, @mobile, @email, @points, @markDelete, @createDate)",
                    new SqlParameter("@Id", Guid.NewGuid()),
                    new SqlParameter("@username", "李四"),
                    new SqlParameter("@password", "123456"),
                    new SqlParameter("@address", "XXXX路ZZ号"),
                    new SqlParameter("@mobile", "13911112222"),
                    new SqlParameter("@email", "lisi@gmial.com"),
                    new SqlParameter("@points", 3),
                    new SqlParameter("@markDelete", false),
                    new SqlParameter("@createDate", DateTime.Now)
                    );
            }
        }


        [Fact]
        public void SqlCommandQueryTest()
        {
            using (var context = new FakeEcDbContext())
            {
                var num = context.Database.ExecuteSqlCommand("INSERT INTO [FakeUser]([Id], [Username], [Password], [Address], [Mobile], [Email], [Points], [MarkDelete], [CreateDate]) VALUES(@username, @password, @address, @mobile, @email, @points, @markDelete, @createDate)",
                    new SqlParameter("@Id", Guid.NewGuid()),
                    new SqlParameter("@username", "李四"),
                    new SqlParameter("@password", "123456"),
                    new SqlParameter("@address", "XXXX路ZZ号"),
                    new SqlParameter("@mobile", "13911112222"),
                    new SqlParameter("@email", "lisi@gmial.com"),
                    new SqlParameter("@points", 3),
                    new SqlParameter("@markDelete", false),
                    new SqlParameter("@createDate", DateTime.Now)
                    );
            }
        }


        [Fact]
        public void SqlCommandConditionQueryTest()
        {
            var result = QueryMethod(Guid.NewGuid(), "zhangsan", "张三", "13422221111", 10, 99, DateTime.Now);
        }

        [Obsolete("未实现。。。")]
        private List<FakeUser> QueryMethod(Guid? id, string username, string name, string mobile, int minPoints, int maxPoints, DateTime maxCreateDate)
        {
            throw new NotImplementedException();

            //var sqlWhere = SqlWhereBuilder.Create()
            //    .And("[Id] = {0}", "@id", id)
            //    .AndSub(e => e.And("[Username] = {0}", "@username", username).Or("[Name] = {0}", "@name", name))
            //    .And("[Mobile] = {0}", "@mobile", mobile)
            //    .AndBetween("[Points] NOT BETWEEN {0} AND {1}", "@minPoints", minPoints, "@maxPoints", maxPoints)
            //    .AndSub(e => e.And("[Points] >= {0}", "@minPoints", minPoints).And("[Points] <= {0}", "@maxPoints", maxPoints))
            //    .And("[CreateDate] <= @maxCreateDate", "@maxCreateDate", maxCreateDate);

            //var sql = "SELECT * FROM [FakeUser] " + sqlWhere.ToWhereString();
            //Trace.WriteLine(sql);
            return null;

        }
    }
}
