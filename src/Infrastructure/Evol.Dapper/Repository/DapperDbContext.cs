using System.Data;
using System.Data.SqlClient;


namespace Evol.Dapper.Repository
{
    public abstract class DapperDbContext
    {

        //public IConfigurationRoot Configuration { get; }
        protected DapperDbContext(string connectionStringName)
        {
            ConnectionStringName = connectionStringName;
            //ConnectionString = Configuration.GetConnectionString(connectionStringName);
            DbConnection = new SqlConnection(ConnectionString);
        }


        public IDbConnection DbConnection { get; private set; }

        public string ConnectionStringName { get; private set; }

        public string ConnectionString { get; private set; }
    }
}
