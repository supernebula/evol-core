using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Evol.Utilities.Hash;

namespace Evol.Web.Filters
{
    public abstract class BaseSignVerificationAttribute : ActionFilterAttribute
    {
        public abstract string GetAppSecret(string appId);

        public override void OnActionExecuting(HttpActionContext httpActionContext)
        {
            base.OnActionExecuting(httpActionContext);
            Validate(httpActionContext);
        }
        /// <summary>
        /// 请求说明
        /// Request Method: POST
        /// 
        /// Request Headers
        /// Accept: application/json (或 application/xml)
        /// Accept-Charset: utf-8
        /// Content-Type: text/json (或 text/xml)
        /// AppId: APPID_VALUE
        /// Timestamp: TIMESTAMP_VALUE (格式：yyyyMMddHHmmss)
        /// Sign: SIGN_VALUE (MD5签名, Sign = MD5(APPSCERET_VALUE+REQUEST_CONTENT_VALUE+TIMESTAMP_VALUE) )
        /// 
        /// Request Body 
        /// Raw: REQUEST_CONTENT_VALUE
        /// 
        /// 注：请求方先申请AppId和AppSceret
        /// </summary>
        /// <param name="httpActionContext"></param>
        private void Validate(HttpActionContext httpActionContext)
        {
            IEnumerable<string> appIds;
            IEnumerable<string> signs;
            IEnumerable<string> timestamps;
            var request = httpActionContext.Request;
            var accepts = request.Headers.Accept.Select(e => e.MediaType).ToArray();
            var appId = request.Headers.TryGetValues("APPID", out appIds) ? appIds.FirstOrDefault() : null;
            var appSecret = GetAppSecret(appId);
            if (String.IsNullOrWhiteSpace(appSecret))
            {
                httpActionContext.Response = ErrorMessage(HttpStatusCode.RequestTimeout, "错误的配置参数");
                return;
            }
            var sign = request.Headers.TryGetValues("SIGN", out signs) ? signs.FirstOrDefault() : null;
            var timestamp = request.Headers.TryGetValues("TIMESTAMP", out timestamps) ? timestamps.FirstOrDefault() : null;
            Stream reqStream = request.Content.ReadAsStreamAsync().Result;
            if (reqStream.CanSeek)
                reqStream.Position = 0;
            var content = new StreamReader(reqStream, Encoding.UTF8).ReadToEnd();
            var signContent = appSecret + content + timestamp;
            var reSign = HashUtility.Md5(signContent);

            if (!IsValidTimestamp(timestamp))
            {
                httpActionContext.Response = ErrorMessage(HttpStatusCode.RequestTimeout, "过期的请求");
                return;
            }
            if (sign != reSign)
                httpActionContext.Response = ErrorMessage(HttpStatusCode.NonAuthoritativeInformation, "签名错误");
        }

        private HttpResponseMessage ErrorMessage(HttpStatusCode statusCode, String message)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(message),
                ReasonPhrase = message,
                StatusCode = statusCode,
                Version = new Version("0.1")
            };
            return response;
        }

        /// <summary>
        /// 判断时间戳是否过期, 默认15分钟
        /// </summary>
        private static bool IsValidTimestamp(string timestamp, double validMinutes = 15)
        {
            DateTime time;
            try
            {
                time = DateTime.ParseExact(timestamp, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                return false;
            }
            return time.AddMinutes(validMinutes) > DateTime.Now;
        }
    }
}
