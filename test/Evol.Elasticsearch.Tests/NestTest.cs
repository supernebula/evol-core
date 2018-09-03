using Elasticsearch.Net;
using Evol.Elasticsearch.Tests.Yelp.Data;
using Nest;
using System;
using System.ComponentModel;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Evol.Elasticsearch.Tests
{
    /// <summary>
    /// http://www.cnblogs.com/ljhdo/p/5160329.html
    /// </summary>
    public class NestTest
    {
        #region Util Method

        void OutputWrite(string str)
        {
            outputHelper.WriteLine("elatic response:\r\n" + str);
        }

        #endregion

        ITestOutputHelper outputHelper;

        public NestTest(ITestOutputHelper output)
        {
            outputHelper = output;
        }

        [Fact]
        [Description("返回指定数量review")]
        public void YelpSelectReviewTest()
        {
            var reviewQuery = new ReviewQuery();
            var items = reviewQuery.Query(0, 100);
            OutputWrite($"数量:{items.Count()}");
            items.ForEach(e => OutputWrite($"id:{e.Id}, flag: {e.Flag}"));

        }



        private ElasticClient GetClient()
        {
            var nodes = new Uri[]
            {
                new Uri("http://192.168.8.198:9200")
            };

            var pool = new StaticConnectionPool(nodes);
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);
            return client;
        }

        [Fact]
        public void TestMethod()
        {
            var client = GetClient();
            var reviewQuery = new ReviewQuery();
            var item = reviewQuery.Query(0, 1).FirstOrDefault();
            Assert.NotNull(item);

            client.Index(item, idx => idx.Index("yelp").Type("review"));
        }
    }
}
