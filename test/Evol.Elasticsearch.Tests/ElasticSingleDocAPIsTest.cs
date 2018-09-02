using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Xunit;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Evol.Util.Serialization;
using Xunit.Abstractions;
using System.Text;

namespace Evol.Elasticsearch.Tests
{

    #region 测试实体

    [DataContract(Name = "twitter")]
    public class Twitter
    {
        public Twitter() { }

        public Twitter(string user, DateTime date, string message)
        {
            User = user;
            PostDate = date;
            Message = message;
        }

        [DataMember(Name = "user")]
        public string User { get; set; }

        [DataMember(Name = "post_date")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }

    #endregion



    /// <summary>
    /// Elasticsearch 单个文档API测试
    /// https://www.elastic.co/guide/en/elasticsearch/reference/current/docs-index_.html
    /// </summary>
    public class ElasticSingleDocAPIsTest
    {
        #region Util Method

        void WriteResponse(string response)
        {
            outputHelper.WriteLine("elatic response:\r\n" + response);
        }

        #endregion

        ITestOutputHelper outputHelper;

        public ElasticSingleDocAPIsTest(ITestOutputHelper output)
        {
            outputHelper = output;
        }

        static string baseUri = "http://192.168.8.198:9200/";

        [Description("查看Es集群是否健康")]
        [Fact]
        public void EsHealthTest()
        {
            var httpClient = new HttpClient();
            var uri = $"{baseUri}_cat/health?v";
            var result = httpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
            Trace.WriteLine(result);
        }


        [Description("获取ES集群的节点列表")]
        [Fact]
        public void EsNodesTest()
        {
            var httpClient = new HttpClient();
            var uri = $"{baseUri}_cat/nodes?v";
            var result = httpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
            Trace.WriteLine(result);
        }

        [Description("列出ES所有索引")]
        [Fact]
        public void EsListIndicesTest()
        {
            var httpClient = new HttpClient();
            var uri = $"{baseUri}_cat/indices?v";
            var response = httpClient.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
            WriteResponse(response);
        }


        [Description("插入索引，自动生成Id")]
        [Fact]
        public void PostIndex()
        {
            var client = new HttpClient();
            var uri = $"{baseUri}twitter/doc/";
            var json = JsonUtil.SerializeByDataContract(new Twitter("wwwwwwww", DateTime.Now, "wwwwHello World!!"));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(uri, content).Result.Content.ReadAsStringAsync().Result;
            WriteResponse(response);

            var result = JsonUtil.DeserializeByDataContract<EsChangeResult>(response);
            Assert.NotNull(result);
            Assert.True(result.Result == "created");
            Assert.True(result.Shards.IsSuccessful);
            WriteResponse(JsonUtil.Serialize(result));
        }

        [Description("插入索引，指定Id；如果id存在，则修改")]
        [Fact]
        public void PutIndex()
        {

            var client = new HttpClient();
            var uri = $"{baseUri}twitter/doc/2";
            var json = JsonUtil.SerializeByDataContract(new Twitter("修改_new-userYYY", DateTime.Now, "修改_put YYY"));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(uri, content).Result.Content.ReadAsStringAsync().Result;
            WriteResponse(response);

            var result = JsonUtil.DeserializeByDataContract<EsChangeResult>(response);
            Assert.NotNull(result);
            Assert.True(result.Result == "created" || result.Result == "updated");
            Assert.True(result.Shards.IsSuccessful);
            WriteResponse(JsonUtil.Serialize(result));
        }

        [Description("获取指定Id的Index")]
        [Fact]
        public void GetIndex()
        {
            var client = new HttpClient();
            var uri = $"{baseUri}twitter/doc/2";
            var response = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
            WriteResponse(response);
            var item = JsonUtil.DeserializeByDataContract<EsGetResult<Twitter>>(response);
            Assert.NotNull(item);
            Assert.True(item.Found);
            Assert.NotNull(item.Source);
            WriteResponse(JsonUtil.Serialize(item.Source));
        }


        [Description("删除指定Index")]
        [Fact]
        public void DeleteIndex()
        {
            var client = new HttpClient();
            var uri = $"{baseUri}twitter/doc/1";
            var response = client.DeleteAsync(uri).Result.Content.ReadAsStringAsync().Result;
            WriteResponse(response);

            var result = JsonUtil.DeserializeByDataContract<EsChangeResult>(response);

            Assert.NotNull(result);
            Assert.True(result.Result == "deleted");
            Assert.True(result.Shards.IsSuccessful);
            WriteResponse(JsonUtil.Serialize(result));
        }

        #region 更新数据 ES指令
            // 1. 这个例子展示如何将id为2文档的message字段更新为 使用了ES的修改指令：
            //   curl -XPOST 'localhost:9200/twitter/doc/2/_update?pretty' -d '
　　        //    {
 　　       //      "doc": { "message": "使用了ES的修改指令" }
　　        //    }'
 

　　        // 2. 这个例子展示如何将id为2数据的message字段更新为Jane Doe同时增加字段nick为 20:

            //    curl -XPOST 'localhost:9200/twitter/doc/1/_update?pretty' -d '
　　        //    {
 　　       //     "doc": { "message": "Jane Doe", "nick": 20 }
　　        //    }'


　　        // 3.  也可以通过一些简单的scripts来执行更新。一下语句通过使用script将年龄增加5:

　　        //   curl -XPOST 'localhost:9200/twitter/doc/1/_update?pretty' -d '
　　        //    {
　　        //      "script" : "ctx._source.age += 5"
　　        //    }'
        #endregion
        [Description("更新指定id的（部分）数据，_update")]
        [Fact]
        public void UpdateIndex()
        {

            var client = new HttpClient();
            var uri = $"{baseUri}twitter/doc/2/_update"; //_update后缀指令

            var json = "{ \"doc\" : {\"message\" : \"使用了ES的修改指令\", \"nick\" : \"飞跃地球\"}}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(uri, content).Result.Content.ReadAsStringAsync().Result;
            WriteResponse(response);

            var result = JsonUtil.DeserializeByDataContract<EsChangeResult>(response);
            Assert.NotNull(result);
            Assert.True(result.Result == "created" || result.Result == "updated");
            Assert.True(result.Shards.IsSuccessful);
            WriteResponse(JsonUtil.Serialize(result));
        }


    }
}

