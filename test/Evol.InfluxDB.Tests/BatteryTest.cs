using AdysTech.InfluxDB.Client.Net;
using Evol.InfluxDB.Tests.Model;
using Evol.Util;
using System;
using System.Collections.Generic;
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
                    client.CreateDatabaseAsync("charge");
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

                var item = new CarBattery();
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


    }
}
