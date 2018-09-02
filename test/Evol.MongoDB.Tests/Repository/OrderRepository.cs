using System;
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
