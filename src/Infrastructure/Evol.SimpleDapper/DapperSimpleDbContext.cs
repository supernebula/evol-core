using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Evol.SimpleDapper
{
    public abstract class DapperSimpleDbContext
    {
        public string ConnectionString { get; private set; }

        public DapperSimpleDbContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));
            ConnectionString = connectionString;
        }

        /// <summary>
        /// 获取当前IDbConnection对象
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetOpenDbConnection()
        {
            var connection = DbSimpleConnectionFactory.GetDbConnection(ConnectionString);
            return connection;
        }

    }
}
