using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.Domain.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.QueryEntries;

namespace Sample.Website.ApiControllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserApiController : Controller
    {
        protected IUserQueryEntry UserQuery { get; private set; }

        protected ICommandBus CommandBus { get; private set; }

        // GET: api/UserApi
        [HttpGet]
        public IEnumerable<string> Get(Guid id)
        {
            return new string[] { "value1", "value2" };
        }
        
    }
}
