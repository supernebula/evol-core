using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Evol.Elasticsearch.Tests
{
    [DataContract]
    public class EsChangeResult
    {
        [DataMember(Name = "_index")]
        public string Index { get; set; }

        [DataMember(Name = "_type")]
        public string Type { get; set; }

        [DataMember(Name = "_id")]
        public string Id { get; set; }

        [DataMember(Name = "_version")]
        public string Version { get; set; }

        [DataMember(Name = "result")]
        public string Result { get; set; }

        [DataMember(Name = "_shards")]
        public EsShards Shards { get; set; }

        [DataMember(Name = "_seq_no")]
        public string SeqNo { get; set; }

        [DataMember(Name = "_primary_term")]
        public string PrimaryTerm { get; set; }

    }


    [DataContract]
    public class EsShards
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "successful")]
        public int Successful { get; set; }

        [DataMember(Name = "failed")]
        public int Failed { get; set; }

        public bool IsSuccessful => Successful == 1;
    }
}
