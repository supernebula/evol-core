using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Utilities.Test.Serialization.ThermModel
{
    public class Payload
    {
        [JsonProperty("deviceType")]
        public string deviceType { get; set; }

        [JsonProperty("iotId")]
        public string iotId { get; set; }

        [JsonProperty("requestId")]
        public string requestId { get; set; }

        [JsonProperty("productKey")]
        public string productKey { get; set; }

        [JsonProperty("gmtCreate")]
        public string gmtCreate { get; set; }

        [JsonProperty("deviceName")]
        public string deviceName { get; set; }

        [JsonProperty("items")]
        public ThermItems Items { get; set; }
    }
}
