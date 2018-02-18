using System.Collections.Generic;
using System.Linq;
using Evol.Fx.EntityFramework.Repository.Test.Core;
using Evol.Test.Models;
using System.Data.SqlClient;
using System;

namespace Evol.Fx.EntityFramework.Repository.Test.Repositories
{
    public class FakeUserRepository : BaseEntityFrameworkRepository<FakeUser, FakeEcDbContext>
    {
        public FakeUserRepository() : this(null)
        {
        }

        public FakeUserRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {


        }
        

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

        [Obsolete("未实现。。")]
        public List<FakeUser> TakeByDbSql(int num = 0)
        {
            string sql = null;
            if (num <= 0)
                sql = "SELECT * FROM [FakeUser]";
            else
                sql = "SELECT TOP " + num + " * FROM [FakeUser]";
            throw new NotImplementedException();
            //https://github.com/aspnet/EntityFramework/issues/1862
            //return Database.ExecuteSqlQueryAsync<FakeUser>(sql).ToList();
        }
    }
}
