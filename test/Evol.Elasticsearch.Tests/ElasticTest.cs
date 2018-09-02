using System;
using Xunit;
using Nest;
using Elasticsearch.Net;
using System.Collections.Generic;
using System.Diagnostics;

namespace Evol.Elasticsearch.Tests
{
    public class Post
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

    }


    /// <summary>
    /// https://social.technet.microsoft.com/wiki/contents/articles/35095.crud-operation-in-elasticsearch-using-c-and-nest.aspx
    /// http://www.ruanyifeng.com/blog/2017/08/elasticsearch.html
    /// https://github.com/elastic/elasticsearch-net
    /// https://www.jianshu.com/p/7fe83806b909
    /// </summary>
    public class ElasticTest
    {
        string searchID = "searchID1";

        private ElasticClient GetEsClient()
        {

            var node = new Uri("http://lcoalhost:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            return client;
        }

        [Fact]
        public void InsertTest()
        {

            var json = new Post()
            {
                Id = 100,
                Name = "关羽",
                Email = "guanyu@163.com",
                Content = "马来西亚总理马哈蒂尔近日接受采访时，被问及对马中合作的关丹产业园区建起了长长的围墙怎么看，他表示应该予以拆除。他说，产业园区不是外国领土，同样需要遵从马来西亚法律，产业园用绵延的围墙把自己封闭起来，还阻挡马来西亚人进入的做法，并不符合马法规"
            };

            var client = GetEsClient();
            var response = client.Index(json, i => i
              .Index("article")
              .Type("detail").Id(searchID).Refresh(Refresh.True));

        }

        [Fact]
        public void MultiInsertTest()
        {
        

            var client = GetEsClient();
            var docs = GenDocs();
            foreach (var item in docs)
            {
                var response = client.Index(item, i => i
                    .Index("article")
                    .Type("detail").Id(searchID).Refresh(Refresh.True));

            }


        }

        [Fact]
        public void FindTest()
        {
 
            var client = GetEsClient();
            var response = client.Search<Post>(s => s
          .Index("article")
          .Type("detail")
          .Query(q => q.Term(t => t.Field("_id").Value(searchID)))); //Search based on _id               

            foreach (var hit in response.Hits)
            {
                var _esid = hit.Id.ToString();
                var name = hit.Source.Name.ToString();
                var email = hit.Source.Email.ToString();
                var content = hit.Source.Content.ToString();

                Trace.WriteLine($"esid:{_esid}");
                Trace.WriteLine($"name:{name}");
                Trace.WriteLine($"email:{email}");
                Trace.WriteLine($"content:{content}");
            }


        }



        List<Post> GenDocs()
        {

            var myJson1 = new Post()
            {
                Id = 3,
                Name = "张三",
                Email = "zhangsan@163.com",
                Content = "侵权责任编草案规定，网络用户、网络服务提供者利用网络侵害他人民事权益的，应当承担侵权责任。网络服务提供者接到通知后，应当及时采取必要措施，并将该通知转送相关网络用户；未及时采取必要措施的，对损害的扩大部分与该网络用户承担连带责任。"
            };

            var myJson2 = new Post()
            {
                Id = 4,
                Name = "李四",
                Email = "56755@qq.com",
                Content = "侵权责任编草案规定，网络用户、网络服务提供者利用网络侵害他人民事权益的，应当承担侵权责任。网络服务提供者接到通知后，应当及时采取必要措施，民法典各分编草案提交全国人大常委会审议，草案包括六编，即物权编、合同编、人格权编、婚姻家庭编、继承编、侵权责任编，共1034条。被喻为社会生活百科全书涉及生活的方方面面，全方位保护你我的权利。"
            };

            var myJson3 = new Post()
            {
                Id = 5,
                Name = "王五",
                Email = "wangwu@163.com",
                Content = "婚姻家庭编草案尊重双方婚姻自主权，规定一方患有严重疾病的，应当在结婚登记前如实告知另一方；不如实告知的，另一方可以向婚姻登记机关或者人民法院请求撤销该婚姻。撤销婚姻的请求，应当自知道或者应当知道撤销事由之日起一年内提出"
            };

            var myJson4 = new Post()
            {
                Id = 6,
                Name = "赵六",
                Email = "zhaoliu@outlook.com",
                Content = "针对群众反映的检车难、排队长等问题，2014年公安部会同原质检总局联合推行机动车检验制度改革，推出私家车6年免检、新车免检、省内异地检车等系列改革措施。目前，已有1.93亿车次享受免检政策，2661万辆车实现省内异地检车"
            };

            var myJson5 = new Post()
            {
                Id = 7,
                Name = "李七",
                Email = "9977886@yahoo.com",
                Content = "为更好适应人民群众对交管服务的新需求、新期待，贯彻落实中央和国务院深入推进审批服务便民化的部署，近日公安部办公厅印发了《公安交管部门进一步深化“放管服”改革提升交管服务便利化的措施》，推出20项交通管理“放管服”改革新措施"
            };

            var list = new List<Post>();
            list.Add(myJson1);
            list.Add(myJson2);
            list.Add(myJson3);
            list.Add(myJson4);
            list.Add(myJson5);

            return list;
        }

    }
}





