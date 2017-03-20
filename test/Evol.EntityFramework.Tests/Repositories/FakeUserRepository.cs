using System.Collections.Generic;
using System.Linq;
using Evol.EntityFramework.Repository.Test.Core;
using Evol.Test.Models;

namespace Evol.EntityFramework.Repository.Test.Repositories
{
    public class FakeUserRepository : BasicEntityFrameworkRepository<FakeUser, FakeEcDbContext>
    {
        public FakeUserRepository()
        {
        }

        public FakeUserRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        { }
        

        public int InsertByCommand(FakeUser item)
        {
            var sql = @"INSERT INTO [dbo].[FakeUser]
                           ([Id]
                           ,[Username]
                           ,[Password]
                           ,[RealName]
                           ,[Gender]
                           ,[Mobile]
                           ,[Email]
                           ,[Address]
                           ,[Points]
                           ,[PersonHeight]
                           ,[Birthday]
                           ,[MarkDelete]
                           ,[CreateDate])
                     VALUES
                           (@Id
                           ,@Username
                           ,@Password
                           ,@RealName
                           ,@Gender
                           ,@Mobile
                           ,@Email
                           ,@Address
                           ,@Points
                           ,@PersonHeight
                           ,@Birthday
                           ,@MarkDelete
                           ,@CreateDate)";
            return Database.ExecuteSqlCommand(sql, new SqlParameter("@Id", item.Id)
                , new SqlParameter("@Username", item.Username)
                , new SqlParameter("@Password", item.Password)
                , new SqlParameter("@RealName", item.RealName)
                , new SqlParameter("@Gender", item.Gender)
                , new SqlParameter("@Mobile", item.Mobile)
                , new SqlParameter("@Email", item.Email)
                , new SqlParameter("@Address", item.Address)
                , new SqlParameter("@Points", item.Points)
                , new SqlParameter("@PersonHeight", item.PersonHeight)
                , new SqlParameter("@Birthday", item.Birthday)
                , new SqlParameter("@MarkDelete", item.SoftDelete)
                , new SqlParameter("@CreateTime", item.CreateTime));
        }


        public List<FakeUser> Take(int num = 0)
        {
            if(num <= 0)
                return DbSet.ToList();
            return DbSet.Take(1000000).ToList();
        }

        public List<FakeUser> TakeByDbSql(int num = 0)
        {
            string sql = null;
            if (num <= 0)
                sql = "SELECT * FROM [FakeUser]";
            else
                sql = "SELECT TOP " + num + " * FROM [FakeUser]";
            return Database.SqlQuery<FakeUser>(sql).ToList();
        }
    }
}
