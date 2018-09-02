using Evol.Common.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using Evol.Fx.Logging.AdapteNLog;
using Evol.Common.Exceptions;

namespace Evol.Fx.Web.Filters
{
    public class CustomApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILoggerFactory _loggerFactory;

        public CustomApiExceptionFilterAttribute()
        {
            _loggerFactory = new NLoggerFactory();
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var code = HttpStatusCode.BadRequest;
            var message = "请求失败!";
            string errorMsg = string.Empty;

            if (actionExecutedContext.Exception is InputError)
            {
                message = "请重新输入";
                code = HttpStatusCode.BadRequest;
                errorMsg = actionExecutedContext.Exception.Message;
            }
            if (actionExecutedContext.Exception is ValidateError)
            {
                message = "请检查输入格式";
                code = HttpStatusCode.BadRequest;
                errorMsg = actionExecutedContext.Exception.Message;
            }

            if (actionExecutedContext.Response == null)
            {
                actionExecutedContext.Response = GetResponse((int)code, message, errorMsg);
            }

            ///ex.api <see cref="nlog.config"/>
            var logger = _loggerFactory.CreateLogger("ex.api");
            logger.LogError(actionExecutedContext.Exception, errorMsg);

            base.OnException(actionExecutedContext);

        }

        private HttpResponseMessage GetResponse(int code, string message, string errorMsg)
         {
             var resultModel = new ApiReponseBaseModel() { Success = ApiReponseStatus.Fail, Code = code, Message = message, ErrorMessage = errorMsg };
 
             return new HttpResponseMessage()
             {
                 Content = new ObjectContent<ApiReponseBaseModel>(
                     resultModel,
                     new JsonMediaTypeFormatter(),
                     "application/json"
                     )
             };
         }
    }
}
