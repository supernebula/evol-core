using System;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.Utilities.Serialization;
using System.Diagnostics;
using Evol.Common;

namespace Evol.Utilities.Test.Serialization
{
    [TestClass]
    public class XmlUtilityTest
    {
        [TestMethod,Description("XML反序列化")]
        public void DeSerializeTest()
        {
            var xml = "<Member><Id>fef4eb92-a1d5-41d6-b6e3-8287bac7e5b8</Id><GenderValue>Female</GenderValue><Types><type>1</type><type>2</type></Types><CreateDate>2016-05-20T13:59:39.1364085+08:00</CreateDate></Member>";
            var obj = XmlUtility.DeSerialize<User>(xml);
            Trace.Write(obj);
            Assert.IsNotNull(obj);
            
        }


        [TestMethod,Description("序列化XML")]
        public void SerializeTest()
        {
            var user = new User() { CreateDate = DateTime.Now, Gender = GenderType.Female, Id = Guid.NewGuid(), Types = new[] { "1", "2" } };
            var str = XmlUtility.Serialize(user);
            Trace.WriteLine(str);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(str));
            
        }

        [TestMethod,Description("序列化返回干净的XML，不包含Namespace")]
        public void SerializeCleanTest()
        {
            var user = new User() { CreateDate = DateTime.Now, Gender = GenderType.Female, Id = Guid.NewGuid() , Types = new[] {"1", "2"}};
            var str = XmlUtility.SerializeClean(user);
            Trace.WriteLine(str);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(str));
        }
    }

    [XmlRoot("Member")]
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [XmlElement("GenderValue")]
        public GenderType Gender { get; set; }

        [XmlArray, XmlArrayItem("type")]
        public string[] Types { get; set; }

        public DateTime CreateDate { get; set; }
    }




    public class Article
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string[] Tags { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
