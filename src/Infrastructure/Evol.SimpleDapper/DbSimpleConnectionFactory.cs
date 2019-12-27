using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Evol.SimpleDapper
{

    public sealed class DbSimpleConnectionFactory
    {
        public static IDbConnection GetDbConnection(string connectionString)
        {

            var connection = new MySqlConnection(connectionString);
            return connection;

        }
    }
}
