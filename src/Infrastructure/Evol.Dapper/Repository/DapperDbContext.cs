using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Evol.Dapper.Repository
{
    public abstract class DapperDbContext
    {

        protected DapperDbContext(string connectionStringName)
        {
            ConnectionStringName = connectionStringName;
            ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            DbConnection = new SqlConnection(ConnectionString);
        }


        public IDbConnection DbConnection { get; private set; }

        public string ConnectionStringName { get; private set; }

        public string ConnectionString { get; private set; }
    }
}
