using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.Utilities.Test.Serialization.ThermModel
{
    public class ThermItems
    {
        [JsonProperty("CurrentHumidity")]
        public ThermHumidity CurrentHumidity { get; set; }

        [JsonProperty("CurrentTemperature")]
        public ThermTemp CurrentTemperature { get; set; }

        [JsonProperty("GeoLocation")]
        public ThermGeoLocation GeoLocation { get; set; }
    }

    public class ThermHumidity
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }
    }

    public class ThermTemp
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }
    }

    public class ThermGeoLocation
    {
        [JsonProperty("value")]
        public ThermGeoValue Value { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }
    }

    public class ThermGeoValue
    {
        [JsonProperty("CoordinateSystem")]
        public int CoordinateSystem { get; set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }

        [JsonProperty("Altitude")]
        public double Altitude { get; set; }

    }
}
