using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.MongoDB.Repository;
using Evol.MongoDB.Test.Entities;

namespace Evol.MongoDB.Test.Repository
{
    public class OrderRepository : BaseMongoDbRepository<Order, TestMongoContext>
    {
        public OrderRepository() : this(null)
        {
        }

        public OrderRepository(IMongoDbContextProvider mongoDbContextProvider) : base(mongoDbContextProvider)
        {
        }
    }
}
