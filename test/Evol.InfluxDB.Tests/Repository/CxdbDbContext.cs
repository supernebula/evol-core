using Evol.SimpleDapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Evol.InfluxDB.Tests.Repository
{
    public class CxdbDbContext : DapperSimpleDbContext
    {
        //public CxdbDbContext() : base(ConfigurationManager.ConnectionStrings["CXEntities"]?.ConnectionString)
        //{
        //}

        public CxdbDbContext() : base("server = 192.168.0.201; Port=3306;user id = chang_chong; password=Qwer1234*;persist security info=True;database=CXDB;charset=utf8;SslMode=none;")
        {
        }

    }
}
