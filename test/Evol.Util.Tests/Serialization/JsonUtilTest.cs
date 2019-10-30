using System;
using Xunit;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Evol.Util.Serialization;
using System.Diagnostics;
using Xunit.Abstractions;
using Evol.Utilities.Test.Serialization.ThermModel;

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
        private readonly ITestOutputHelper output;

        public JsonUtilTest(ITestOutputHelper output)
        {
            this.output = output;
        }

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

        [Fact]
        public void AliIotPayloadDesTest()
        {
            var json = "{\"deviceType\":\"TemperatureHumidityDetector\",\"iotId\":\"Xz0l9ZIXluEr9wrGKp9L000100\",\"requestId\":\"123\",\"productKey\":\"a1lH5vdBSs8\",\"gmtCreate\":1572404537493,\"deviceName\":\"therm10001\",\"items\":{\"CurrentHumidity\":{\"value\":20.9,\"time\":1572404537496},\"CurrentTemperature\":{\"value\":12.99,\"time\":1572404537496},\"GeoLocation\":{\"value\":{\"CoordinateSystem\":1,\"Latitude\":3.19,\"Longitude\":-9.41,\"Altitude\":7922.42},\"time\":1572404537496}}}";

            //var json = "{\"deviceType\":\"TemperatureHumidityDetector\",\"iotId\":\"Xz0l9ZIXluEr9wrGKp9L000100\",\"requestId\":\"123\",\"productKey\":\"a1lH5vdBSs8\",\"gmtCreate\":1572404537493,\"deviceName\":\"therm10001\",\"items\":{\"CurrentHumidity\":{\"value\":20.9,\"time\":1572404537496},\"CurrentTemperature\":{\"value\":12.99,\"time\":1572404537496},\"GeoLocation\":{\"time\":1572404537496}}}";

            var payload = JsonUtil.Deserialize<Payload>(json);
        }
    }
}
