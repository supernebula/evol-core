using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Evol.Web.Exceptions
{
    /// <summary>
    /// 输入异常
    /// </summary>
    [DataContract]
    [JsonObject]
    public class InputError : Exception
    {
        [DataMember]
        public Dictionary<string, string> ModelError { get; private set; }

        [DataMember]
        public Exception Exception { get; private set; }

        public InputError(Dictionary<string, string> modelErrorDic, string message, Exception innerEx = null)  
            : base(message, innerEx)
        {
            ModelError = modelErrorDic;
        }
    }
}
