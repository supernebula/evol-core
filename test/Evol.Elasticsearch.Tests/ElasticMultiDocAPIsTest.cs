using Evol.Util.Serialization;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Evol.Elasticsearch.Model.Tests;

namespace Evol.Elasticsearch.Tests
{
    public class ElasticMultiDocAPIsTest
    {

        #region Util Method

        void WriteResponse(string response)
        {
            outputHelper.WriteLine("elatic response:\r\n" + response);
        }

        #endregion

        ITestOutputHelper outputHelper;

        public ElasticMultiDocAPIsTest(ITestOutputHelper output)
        {
            outputHelper = output;
        }

        static string baseUri = "http://192.168.8.198:9200/";


        #region 批处理 ES指令

        //  例:

　　    //   1.下面语句将在一个批量操作中执行创建索引：

　　    //    curl -XPOST 'localhost:9200/customer/external/_bulk?pretty' -d '
　　    //    {"index":{"_id":"1"}}
　　    //    {"name": "John Doe" }
　　    //    {"index":{"_id":"2"}}
　　    //    {"name": "Jane Doe" }
　　    //    '
　　    //   2.下面语句批处理执行更新id为1的数据然后执行删除id为2的数据

        //    curl -XPOST 'localhost:9200/customer/external/_bulk?pretty' -d '
　　    //    {"update":{"_id":"1"}}
　　    //    {"doc": { "name": "John Doe becomes Jane Doe" } }
　　    //    {"delete":{"_id":"2"}}
　　    //    '


        #endregion


        [Description("批量创建索引")]
        [Fact]
        public void MultiPostIndex()
        {
            var client = new HttpClient();
            var uri = $"{baseUri}twitter/doc/_bulk";
            var sb = new StringBuilder();
            sb.AppendLine("{\"index\":{\"_id\":\"29\"}}");
            sb.AppendLine("{\"name\": \"John Doe\" }");
            sb.AppendLine("{\"index\":{\"_id\":\"20\"}}");
            sb.AppendLine("{\"name\": \"Jane Doe\" }");
            var json = sb.ToString();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(uri, content).Result.Content.ReadAsStringAsync().Result;
            WriteResponse(response);

            var result = JsonUtil.DeserializeByDataContract<EsMultiChangeResult>(response);
            Assert.NotNull(result);
            Assert.False(result.Errors);
            Assert.NotNull(result.Items);
            Assert.True(result.Items.Count > 0);
            WriteResponse(JsonUtil.Serialize(result));
        }

        #region 导入数据集
        //例： 有数据集文件， accounts.json，格式如下：

        //    {
     　　 //      "index":{"_id":"1"}
　　      //  }
　　      //  {
 　　     //      "account_number": 0,
   　　   //      "balance": 16623,
  　　    //      "firstname": "Bradshaw",
   　　   //      "lastname": "Mckenzie",
   　　   //      "age": 29,
   　　   //      "gender": "F",
 　　     //      "address": "244 Columbus Place",
  　　    //      "employer": "Euron",
   　　   //      "email": "bradshawmckenzie@euron.com",
   　　   //      "city": "Hobucken",
   　　   //      "state": "CO"
　　      //  }

        //    导入命令如下：
        //     curl -XPOST 'localhost:9200/bank/account/_bulk?pretty' --data-binary "@accounts.json"
　　      //   curl 'localhost:9200/_cat/indices?v'


#endregion



        [Description("导入数据集")]
        [Fact]
        public void ImportIndex()
        {
            //todo 
        }
    }
}
