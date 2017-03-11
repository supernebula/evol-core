using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.MongoDB.Test.Entities;
using MongoDB.Bson.Serialization;

namespace Evol.MongoDB.Test.MongoMap
{
    public class OrderMap
    {
        public OrderMap()
        {
            BsonClassMap.RegisterClassMap<Order>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(e => e.Id);
            });

        }
    }
}
