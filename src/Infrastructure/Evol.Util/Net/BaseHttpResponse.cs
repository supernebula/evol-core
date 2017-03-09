using System;

namespace Evol.Util.Net
{

    /// <summary>
    /// 基础响应
    /// </summary>
    /// <typeparam name="T">返回值</typeparam>
    public class BaseHttpResponse<T> where T : new()
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccessed { get; set; }


        /// <summary>
        /// 返回值
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 响应正文
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception { get; set; }
    }
}
