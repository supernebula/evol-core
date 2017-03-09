using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Evol.Util.Net
{
    public class BaseClient
    {


        /// <summary>
        /// 创建方法
        /// </summary>
        /// <param name="baseUri">请求的资源地址</param>
        /// <param name="accept">HTTP请求头 accept, 例如: application/json、 text/xml</param>
        /// <returns></returns>
        public static BaseClient CreateClient(string baseUri, string accept = null)
        {
            return new BaseClient(baseUri, accept);

        }


        private readonly HttpClient _httpClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uri">请求的资源地址</param>
        /// <param name="accept">HTTP请求头 accept, 例如: application/json、 text/xml</param>
        public BaseClient(string uri, string accept)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(uri);
            if (accept != null)
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
        }

        /// <summary>
        /// 容错请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        private BaseHttpResponse<T> Failover<T>(Func<BaseHttpResponse<T>> func) where T : new()
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception ex)
            {
                return new BaseHttpResponse<T>() { IsSuccessed = false, Data = default(T), Content = ex.Message, Exception = ex };
            }
        }


        /// <summary>
        /// 尝试转换
        /// </summary>
        /// <typeparam name="T">转换结果</typeparam>
        /// <param name="source">待转换字符串</param>
        /// <param name="converter">转换方法</param>
        /// <returns>bool:是否转换成功,T:转换结果,Exception:转换失败异常</returns>
        private Tuple<bool, T, Exception> TryConvert<T>(string source, Func<string, T> converter)
        {
            try
            {
                var result = converter.Invoke(source);
                return new Tuple<bool, T, Exception>(true, result, null);
            }
            catch (Exception ex)
            {
                return new Tuple<bool, T, Exception>(false, default(T), ex);
            }
        }

        /// <summary>
        /// HTTP GET 请求
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="addressSuffix">完成地址：baseUri + addressSuffix</param>
        /// <param name="converter">响应结果转换器(反序列化..)</param>
        /// <returns></returns>
        public BaseHttpResponse<T> Get<T>(string addressSuffix, Func<string, T> converter) where T : new()
        {
            return Failover(() =>
            {
                var result = _httpClient.GetAsync(addressSuffix).Result.Content.ReadAsStringAsync().Result;
                var tuple = TryConvert(result, converter);
                return new BaseHttpResponse<T>() { IsSuccessed = tuple.Item1, Data = tuple.Item2, Content = result, Exception = tuple.Item3 };
            });

        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="addressSuffix">完成地址：baseUri + addressSuffix</param>
        /// <param name="data">HttpContent</param>
        /// <param name="converter">响应结果转换器(反序列化..)</param>
        /// <returns></returns>
        public BaseHttpResponse<T> Post<T>(string addressSuffix, HttpContent data, Func<string, T> converter) where T : new()
        {
            return Failover(() =>
            {
                var result = _httpClient.PostAsync(addressSuffix, data).Result.Content.ReadAsStringAsync().Result;
                var tuple = TryConvert(result, converter);
                return new BaseHttpResponse<T>() { IsSuccessed = tuple.Item1, Data = tuple.Item2, Content = result, Exception = tuple.Item3 };
            });

        }




    }
}
