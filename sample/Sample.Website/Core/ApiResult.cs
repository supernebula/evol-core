using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Website.Core
{

    /// <summary>
    /// 平台请求处理状态
    /// </summary>
    public enum PlatfamCode
    {
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 0,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 1
    }

    /// <summary>
    /// 平台请求处理状态
    /// </summary>
    public enum BusinessCode
    {
        /// <summary>
        /// 处理成功
        /// </summary>
        Ok = 200,

        /// <summary>
        ///未找到
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// 服务端处理异常
        /// </summary>
        ServerError = 500,

    }

    /// <summary>
    /// 返回结果类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult
    {
        public ApiResult()
        {

        }

        public ApiResult(object obj)
        {
            Data = obj;
        }

        /// <summary>
        /// 平台状态码0，1
        /// </summary>
        public PlatfamCode Code { get; set; }

        /// <summary>
        /// 平台状态信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 业务处理状态码
        /// </summary>
        public BusinessCode ErrCode { get; set; }

        /// <summary>
        /// 业务接口处理信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        public static ApiResult Ok => new ApiResult()
        {
            Code = PlatfamCode.Success,
            Msg = "请求成功",
            ErrCode = BusinessCode.Ok,
            ErrMsg = "成功",
            Data = null
        };

    }
}
