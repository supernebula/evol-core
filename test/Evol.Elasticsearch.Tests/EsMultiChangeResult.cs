using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Evol.Elasticsearch.Tests
{
    [DataContract]
    public class EsMultiChangeResult
    {
        [DataMember(Name = "took")]
        public int Took { get; set; }

        [DataMember(Name = "errors")]
        public bool Errors { get; set; }

        [DataMember(Name = "items")]
        public List<EsMultiChangeResultItem> Items { get; set; }
    }

    public class EsMultiChangeResultItem
    {
        [DataMember(Name = "index")]
        public EsChangeStatusResult Index { get; set; }

    }

    [DataContract]
    public class EsChangeStatusResult : EsChangeResult
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }
    }
}
