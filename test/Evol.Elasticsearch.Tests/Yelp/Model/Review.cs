using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Evol.Elasticsearch.Tests.Yelp.Model
{
    [DataContract(Name = "review")]
    public class Review
    {

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "stars")]
        public int Stars { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "useful")]
        public int Useful { get; set; }

        [DataMember(Name = "funny")]
        public int Funny { get; set; }

        [DataMember(Name = "cool")]
        public int Cool { get; set; }

        [DataMember(Name = "business_id")]
        public string BusinessId { get; set; }

        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "flag")]
        public int Flag { get; set; }
    }
}
