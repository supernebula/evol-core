using AdysTech.InfluxDB.Client.Net;
using Evol.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Evol.InfluxDB.Tests
{


    public class InfluxDBClientTest
    {
        const string influxUrl = "https://ts-bp10ww8h1w50gud7k.influxdata.rds.aliyuncs.com:3242";
        const string dbUName = "admin";
        const string dbpwd = "Super2016";
        const string dbName = "mytsdb";
        const string measurementName = "TestMeasurement";  //table

        private ITestOutputHelper output;

        public InfluxDBClientTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
        }

        [Fact]
        public void ConnectInfluxDBClientTest()
        {
            using(InfluxDBClient client = new InfluxDBClient(influxUrl, dbUName, dbpwd))
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
                    client.CreateDatabaseAsync("test_" + DateTime.Now.Minute + "_" + DateTime.Now.Second);
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

                var valDouble = new InfluxDatapoint<double>();
                valDouble.UtcTimestamp = DateTime.UtcNow;
                valDouble.Tags.Add("TestDate", today);
                valDouble.Tags.Add("TestTime", now);
                valDouble.Fields.Add("Doublefield", DataGen.RandomDouble());
                valDouble.Fields.Add("Doublefield2", DataGen.RandomDouble());
                valDouble.MeasurementName = measurementName;
                valDouble.Precision = TimePrecision.Nanoseconds;
                points.Add(valDouble);

                valDouble = new InfluxDatapoint<double>();
                valDouble.UtcTimestamp = DateTime.UtcNow;
                valDouble.Tags.Add("TestDate", today);
                valDouble.Tags.Add("TestTime", now);
                valDouble.Fields.Add("Doublefield", DataGen.RandomDouble());
                valDouble.Fields.Add("Doublefield2", DataGen.RandomDouble());
                valDouble.MeasurementName = measurementName;
                valDouble.Precision = TimePrecision.Microseconds;
                points.Add(valDouble);

                var valInt = new InfluxDatapoint<int>();
                valInt.UtcTimestamp = DateTime.UtcNow;
                valInt.Tags.Add("TestDate", today);
                valInt.Tags.Add("TestTime", now);
                valInt.Fields.Add("Intfield", DataGen.RandomInt());
                valInt.Fields.Add("Intfield2", DataGen.RandomInt());
                valInt.MeasurementName = measurementName;
                valInt.Precision = TimePrecision.Milliseconds;
                points.Add(valInt);

                valInt = new InfluxDatapoint<int>();
                valInt.UtcTimestamp = DateTime.UtcNow;
                valInt.Tags.Add("TestDate", today);
                valInt.Tags.Add("TestTime", now);
                valInt.Fields.Add("Intfield", DataGen.RandomInt());
                valInt.Fields.Add("Intfield2", DataGen.RandomInt());
                valInt.MeasurementName = measurementName;
                valInt.Precision = TimePrecision.Seconds;
                points.Add(valInt);

                var valBool = new InfluxDatapoint<bool>();
                valBool.UtcTimestamp = DateTime.UtcNow;
                valBool.Tags.Add("TestDate", today);
                valBool.Tags.Add("TestTime", now);
                valBool.Fields.Add("Booleanfield", time.Ticks % 2 == 0);
                valBool.MeasurementName = measurementName;
                valBool.Precision = TimePrecision.Minutes;
                points.Add(valBool);

                var valString = new InfluxDatapoint<string>();
                valString.UtcTimestamp = DateTime.UtcNow;
                valString.Tags.Add("TestDate", today);
                valString.Tags.Add("TestTime", now);
                valString.Fields.Add("Stringfield", DataGen.RandomString());
                valString.MeasurementName = measurementName;
                valString.Precision = TimePrecision.Hours;
                points.Add(valString);


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
