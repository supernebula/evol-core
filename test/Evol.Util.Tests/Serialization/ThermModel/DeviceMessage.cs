using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Utilities.Test.Serialization.ThermModel
{
    public class DeviceMessage
    {
        [JsonProperty("messageid")]
        public string MessageId { get; set; }

        [JsonProperty("messagetype")]
        public string MessageType { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
