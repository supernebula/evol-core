using System.Runtime.Serialization;

namespace Evol.Elasticsearch.Model.Tests
{
    [DataContract]
    public class EsGetResult<T>
    {
        [DataMember(Name = "_index")]
        public string Index { get; set; }

        [DataMember(Name = "_type")]
        public string Type { get; set; }

        [DataMember(Name = "_id")]
        public string Id { get; set; }

        [DataMember(Name = "_version")]
        public string Version { get; set; }

        [DataMember(Name = "found")]
        public bool Found { get; set; }

        [DataMember(Name = "_source")]
        public T Source { get; set; }

    }
}
