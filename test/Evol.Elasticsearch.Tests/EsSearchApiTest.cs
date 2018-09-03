using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;
using Evol.Elasticsearch.Model.Tests;

namespace Evol.Elasticsearch.Tests
{
    /// <summary>
    /// 搜索测试
    /// Search APIs
    /// https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html
    /// 
    /// https://www.elastic.co/guide/en/elasticsearch/reference/current/query-filter-context.html
    /// 
    /// https://www.elastic.co/guide/en/elasticsearch/reference/current/indices.html
    /// 
    /// 
    /// https://www.cnblogs.com/pilihaotian/p/5830754.html
    /// </summary>
    public class EsSearchApiTest
    {

        #region Util Method

        void WriteResponse(string response)
        {
            outputHelper.WriteLine("elatic response:\r\n" + response);
        }

        #endregion


        static string baseUri = "http://192.168.8.198:9200/";

        ITestOutputHelper outputHelper;

        public EsSearchApiTest(ITestOutputHelper output)
        {
            outputHelper = output;
        }

        /// <summary>
        /// q=*  表示匹配索引中所有的数据
        /// 等价于:
        ///  curl -XPOST 'localhost:9200/bank/_search?pretty' -d '
　　    ///   {
　　    ///       "query": { "match_all": {} }
　　    ///   }'
        /// </summary>
        [Description("返回所有twitter中的索引数据")]
        [Fact]
        public void SearchAllTest()
        {
            var uri = $"{baseUri}twitter/_search?q=*&pretty";
            var httpClient = new HttpClient();
            var result = httpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
            WriteResponse(result);
        }

        /// <summary>
        /// 　　curl -XPOST 'localhost:9200/bank/_search?pretty' -d '
        ///       {
        ///         "query": { "match_all": {} },
        ///         "size": 1
        ///       }'
        ///       
        /// </summary>
        [Description("匹配所有数据，只返回1条； 不指定size，默认返回10条")]
        [Fact]
        public void MatchAllButGetOneTest()
        {
            //todo
            Assert.True(false);
        }

        /// <summary>
        /// 　　curl -XPOST 'localhost:9200/bank/_search?pretty' -d '
　　    ///  {
  　　  ///    "query": { "match_all": {} },
　　    ///    "from": 10,
 　　   ///    "size": 10
　　    ///  }'
        /// </summary>
        [Description("匹配所有数据，返回从11到20的数据")]
        [Fact]
        public void MatchAllButOffsetLimitTest()
        {
            //todo
            Assert.True(false);
        }


    }
}
