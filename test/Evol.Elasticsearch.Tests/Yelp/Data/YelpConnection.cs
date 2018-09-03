using System;
using System.Collections.Generic;
using System.Text;
using MySqlClient = MySql.Data.MySqlClient;
using System.Configuration;

namespace Evol.Elasticsearch.Tests.Yelp.Data
{
    public class YelpConnectionFactory
    {
        static YelpConnectionFactory _instance;
        public static YelpConnectionFactory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new YelpConnectionFactory();
                return _instance;
            }
        }

        public MySqlClient.MySqlConnection GetMySqlConnection(string connectionStringName)
        {
            //var connectionString = "Host=192.168.8.198;UserName=admin;Password=?super2016;Database=yelp_db;SslMode=none;";
            var connectionString = "server=192.168.8.198;port=3306;database=yelp_db;user=admin;password=?super2016;SslMode = none;";
            //var connectionString = ConfigurationManager.AppSettings[connectionStringName];
            return new MySqlClient.MySqlConnection(connectionString);
        }
    }
}
