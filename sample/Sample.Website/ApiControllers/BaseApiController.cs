using System.Collections.Generic;
using System.Linq;
using Evol.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Sample.Website.ApiControllers
{
    public abstract class BaseApiController : Controller
    {
        /// <summary>
        /// 验证Model，如果验证失败，抛出异常
        /// </summary>
        protected void ValidateModelOrThrow()
        {
            if (ModelState.IsValid)
                return;

            var keys = ModelState.Keys;
            var modelError = new Dictionary<string, string>();
            foreach (var key in keys)
            {
                ModelStateEntry modeState = null;
                if (ModelState.TryGetValue(key, out modeState) && modeState != null && modeState.ValidationState != ModelValidationState.Valid)
                {
                    var error = new KeyValuePair<string, string>(key, string.Join(";", modeState.Errors.Select(e => e.ErrorMessage)));
                    modelError.Add(error.Key, error.Value);
                } 
            }

            var rootMsg = "输入错误！";
            if (ModelState.Root.Errors.Any())
                rootMsg = string.Join(";", ModelState.Root.Errors.Select(e => e.ErrorMessage));
            var err = new InputError(modelError, rootMsg);
            throw err;
        }
    }
}