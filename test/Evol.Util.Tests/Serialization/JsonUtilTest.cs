using System;
using Xunit;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Evol.Util.Serialization;
using System.Diagnostics;

namespace Evol.Utilities.Test.Serialization
{
    #region Test Object
    /// <summary>
    /// 输入异常
    /// </summary>
    [DataContract]
    [JsonObject]
    public class InputError : Exception
    {

        [DataMember]
        //[Newtonsoft.Json.JsonProperty]
        public Dictionary<string, string> ModelError { get; private set; }

        [DataMember]
        public Exception Exception { get; private set; }

        public InputError(Dictionary<string, string> modelErrorDic, string message, Exception innerEx = null)
            : base(message, innerEx)
        {
            ModelError = modelErrorDic;
        }
    }

    #endregion

    public class JsonUtilTest
    {
        [Fact]
        public void ExceptionSerializerTest()
        {
            try
            {
                var errDic = new Dictionary<string, string>();
                errDic.Add("Name", "名称不能为空");
                var ex1 = new InputError(errDic, "输入错误！", null);
                var content = JsonUtil.Serialize(ex1);
                Trace.Write(content);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [Fact]
        public void JavaScriptSerializerTest()
        {
            var dic = new Dictionary<string, string>() {
                { "Name","Name 不能为空" },
                { "Sort","排序不能为空" },
                { "Url","链接不能为空" }
            };

            dic = null;

           // var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dic);
        }
    }
}
