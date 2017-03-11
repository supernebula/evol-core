using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Evol.Utilities.Test.Serialization
{
    [TestClass]
    public class JavaScriptTest
    {
        [TestMethod]
        public void JavaScriptSerializerTest()
        {
            var dic = new Dictionary<string, string>() {
                { "Name","Name 不能为空" },
                { "Sort","排序不能为空" },
                { "Url","链接不能为空" }
            };

            dic = null;

            var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dic);
        }
    }
}
