using Evol.Web.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
                var errorMessage = ModelState.Where(e => e.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).ToDictionary(e => e.Key, e => e.Value.Errors.First().ErrorMessage);
                throw new InputError(errorMessage, "输入验证失败");
            }
        }
    }
}
