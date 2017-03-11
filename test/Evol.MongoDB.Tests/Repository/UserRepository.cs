using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.MongoDB.Repository;
using Evol.MongoDB.Test.Entities;

namespace Evol.MongoDB.Test.Repository
{

    public class UserRepository : BaseMongoDbRepository<User, TestMongoContext>
    {
        public UserRepository()
        {
        }

        public UserRepository(IMongoDbContextFactory mongoDbContextFactory) : base(mongoDbContextFactory)
        {
        }
    }
}
