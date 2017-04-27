using System;
using System.Data;
using System.Data.SqlClient;


namespace Evol.Dapper
{
    public abstract class DapperDbContext
    {

        protected DapperDbContext(DapperDbOptions options)
        {
            DbConnection = options.DbConnectionthunk.Invoke();
            DbContext = options.DbContext;
        }


        public IDbConnection DbConnection { get; private set; }

        public Type DbContext { get; private set; }
    }

    public class DapperDbOptions<TDbContext> : DapperDbOptions
    {
        public override Type DbContext => typeof(TDbContext);
    }

    public class DapperDbOptions
    {
        public virtual Type DbContext { get; protected set; }
        public Func<IDbConnection> DbConnectionthunk { get; set; }
    }
}
