using AdysTech.InfluxDB.Client.Net;
using Evol.InfluxDB.Tests.Model;
using Evol.InfluxDB.Tests.Repository;
using Evol.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace Evol.InfluxDB.Tests
{

    public class BatteryTest
    {
        const string influxUrl = "https://ts-bp10ww8h1w50gud7k.influxdata.rds.aliyuncs.com:3242";
        const string dbUName = "admin";
        const string dbpwd = "Super2016";
        const string dbName = "charge";
        const string measurementName = "CarBattery";  //table

        private ITestOutputHelper output;

        public BatteryTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
        }

        [Fact]
        public void ConnectInfluxDBClientTest()
        {
            using (InfluxDBClient client = new InfluxDBClient(influxUrl, dbUName, dbpwd))
            {
                var temp = client;
            }

        }

        [Fact]
        public void TestGetInfluxDBNames()
        {
            using (InfluxDBClient client = new InfluxDBClient(influxUrl, dbUName, dbpwd))
            {
                TimeMonitor.Watch(nameof(TestGetInfluxDBNames), () =>
                {
                    var dbNames = client.GetInfluxDBNamesAsync().Result;
                    var temp = dbNames;
                }, output.WriteLine);
            }
        }



        [Fact]
        public void CreateInfluxDatabaseTest()
        {
            using (InfluxDBClient client = new InfluxDBClient(influxUrl, dbUName, dbpwd))
            {
                TimeMonitor.Watch(nameof(TestGetInfluxDBNames), () =>
                {
                    client.CreateDatabaseAsync(dbName);
                    var dbNames = client.GetInfluxDBNamesAsync().Result;
                    var temp = dbNames;
                }, output.WriteLine);
            }
        }

        [Fact]
        public void DeleteInfluxDatabaseTest()
        {
            using (InfluxDBClient client = new InfluxDBClient(influxUrl, dbUName, dbpwd))
            {
                TimeMonitor.Watch(nameof(TestGetInfluxDBNames), () =>
                {
                    client.CreateDatabaseAsync(dbName);
                    var dbNames = client.GetInfluxDBNamesAsync().Result;
                    var temp = dbNames;
                }, output.WriteLine);
            }
        }

        [Fact]
        public void TestPostPointLoop()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(nameof(TestPostPointLoop) + "_" + i);
                TestPostPoints();
                Thread.Sleep(10000);


            }
        }



        [Fact]
        public void TestPostPoints()
        {
            try
            {
                var client = new InfluxDBClient(influxUrl, dbUName, dbpwd);
                var time = DateTime.Now;
                var today = DateTime.Now.ToShortDateString();
                var now = DateTime.Now.ToShortTimeString();

                var points = new List<IInfluxDatapoint>();

                var item = new CarBatteryPoint();
                item.DeviceNumber = "";
                item.CustomerCode = "";
                item.DeviceWays = "";
                item.TransactionID = "";
                item.VIN = "";
                item.RVOL = DataGen.RandomDouble();
                item.RCUR = DataGen.RandomDouble();
                item.Ptemp = DataGen.RandomDouble();
                item.Ntemp = DataGen.RandomDouble();
                item.BATType = DataGen.RandomDouble();
                item.BATPOW = DataGen.RandomDouble();
                item.Capacity = DataGen.RandomDouble();
                item.MaxCVol = DataGen.RandomDouble();
                item.MaxCCur = DataGen.RandomDouble();
                item.SigleMaxVol = DataGen.RandomDouble();
                item.SigleMinVol = DataGen.RandomDouble();
                item.StartSigleMaxVol = DataGen.RandomDouble();
                item.StartSigleMinVol = DataGen.RandomDouble();
                item.EndSigleMaxVol = DataGen.RandomDouble();
                item.EndSigleMinVol = DataGen.RandomDouble();
                item.MaxTemp = DataGen.RandomDouble();
                item.StartVol = DataGen.RandomDouble();
                item.CreateDate = DateTime.UtcNow;
                item.MeasurementName = measurementName;
                item.Precision = TimePrecision.Nanoseconds;
                points.Add(item);

               


                var r = client.PostPointsAsync(dbName, points).Result;
                Assert.True(r, "PostPointsAsync retunred false");
            }
            catch (Exception e)
            {

                //Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
                return;
            }
        }


        [Fact]
        public void InsertBatteryPointsTest()
        {
            //var now = DateTime.Now;
            //var utcNow = DateTime.UtcNow;
            //var convertUtc = TimeZone.CurrentTimeZone.ToUniversalTime(now);

           // var config = new ConfigurationBuilder()
           //.AddJsonFile("appsettings.json")
           //.Build();
           // var connectionString = config["Data:CXEntities:ConnectionString"];

           // var connStr = ConfigurationManager.ConnectionStrings["CXEntities"]?.ConnectionString;
           // string conString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnection");

           // return;

            var client = new InfluxDBClient(influxUrl, dbUName, dbpwd);

            var batteryRepos = new CarBatteryRepository();
            var batteries = batteryRepos.Query("SELECT * FROM carbattery").ToList();

            //return;
            batteries.ForEach(e =>
            {
                var item = new CarBatteryPoint();
                item.DeviceNumber = NoEmptyValue(e.DeviceNumber, "DeviceNumber");
                item.CustomerCode = NoEmptyValue(e.CustomerCode, "CustomerCode");
                item.DeviceWays = NoEmptyValue(e.DeviceWays, "DeviceWays");
                item.TransactionID = NoEmptyValue(e.TransactionID, "TransactionID");
                item.VIN = NoEmptyValue(e.VIN, "VIN");
                item.RVOL = e.RVOL;
                item.RCUR = e.RCUR;
                item.Ptemp = e.Ptemp;
                item.Ntemp = e.Ntemp;
                item.BATType = e.BATType;
                item.BATPOW = e.BATPOW;
                item.Capacity = e.Capacity;
                item.MaxCVol = e.MaxCVol;
                item.MaxCCur = e.MaxCCur;
                item.SigleMaxVol = e.SigleMaxVol;
                item.SigleMinVol = e.SigleMinVol;
                item.StartSigleMaxVol = e.StartSigleMaxVol;
                item.StartSigleMinVol = e.StartSigleMinVol;
                item.EndSigleMaxVol = e.EndSigleMaxVol;
                item.EndSigleMinVol = e.EndSigleMinVol;
                item.MaxTemp = e.MaxTemp;
                item.StartVol = e.StartVol;
                var utcTime = TimeZone.CurrentTimeZone.ToUniversalTime(e.CreateDate);
                item.CreateDate = utcTime;
                item.MeasurementName = measurementName;
                item.Precision = TimePrecision.Nanoseconds;
                var r = client.PostPointAsync(dbName, item).Result;
                output.WriteLine("add point:" + e.Id);
            });
        }

        private string NoEmptyValue(string value, string defualtValue)
        {
            if (String.IsNullOrWhiteSpace(value))
                return defualtValue;
            return value;
        }


    }
}
