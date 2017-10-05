using Evol.Web.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Manage.Apis
{
    public abstract class ApiBaseController : Controller
    {
        /// <summary>
        /// 如果ModelState验证失败，则抛出异常
        /// </summary>
        protected void ThrowIfNotModelIsValid()
        {
            if (!ModelState.IsValid)
            {
                var errorState = ModelState.Select(e => new KeyValuePair<string, string>(e.Key, e.Value.RawValue.ToString())).ToDictionary(e => e.Key, e => e.Value);
                throw new InputError(errorState, "输入验证失败");
            }
        }
    }
}
