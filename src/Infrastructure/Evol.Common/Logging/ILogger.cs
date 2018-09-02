using System;
using System.Linq.Expressions;

namespace Evol.Common.Logging
{
    public interface ILogger
    {

        void LogData<T>(T model);

        void LogCritical(Exception exception, string message, params object[] args);

        void LogCritical(EventId eventId, string message, params object[] args);

        void LogCritical(EventId eventId, Exception exception, string message, params object[] args);

        void LogCritical(string message, params object[] args);
                                              
        void LogDebug(EventId eventId, Exception exception, string message, params object[] args);

        void LogDebug(EventId eventId, string message, params object[] args);

        void LogDebug(Exception exception, string message, params object[] args);

        void LogDebug(string message, params object[] args);

        void LogError(EventId eventId, Exception exception, string message, params object[] args);

        void LogError(EventId eventId, string message, params object[] args);

        void LogError(Exception exception, string message, params object[] args);

        void LogError(string message, params object[] args);

        void LogInformation(EventId eventId, Exception exception, string message, params object[] args);

        void LogInformation(EventId eventId, string message, params object[] args);

        void LogInformation(Exception exception, string message, params object[] args);

        void LogInformation(string message, params object[] args);
                                                 
        void LogTrace(Exception exception, string message, params object[] args);
               
        void LogTrace(string message, params object[] args);

        void LogTrace(EventId eventId, Exception exception, string message, params object[] args);

        void LogTrace(EventId eventId, string message, params object[] args);
                                           
        void LogWarning(string message, params object[] args);

        void LogWarning(EventId eventId, string message, params object[] args);

        void LogWarning(Exception exception, string message, params object[] args);

        void LogWarning(EventId eventId, Exception exception, string message, params object[] args);

        /// <summary>
        /// 记录基本操作日志
        /// </summary>
        /// <param name="operateType">操作类型 <see cref="BasicOperateLogType"/></param>
        /// <param name="ip">操作人IP</param>
        /// <param name="original">原始值</param>
        /// <param name="current">当前值</param>
        /// <param name="remark">备注</param>
        /// <param name="operatorId">操作人编号</param>
        /// <param name="operatorName">操作人名称</param>
        void LogBasicOperate(BasicOperateLogType operateType, string remoteAddr, string host, string operatorId, string operatorName, string original = "", string current = "", string remark = "");

        /// <summary>
        /// 记录访问审计日志
        /// </summary>
        /// <param name="host">服务器主机IP</param>
        /// <param name="remoteAddr">用户实际IP</param>
        /// <param name="httpReferer">来源url</param>
        /// <param name="httpMethod">http请求方式</param>
        /// <param name="http">http协议</param>
        /// <param name="request">请求地址</param>
        /// <param name="bodyLength">响应长度</param>
        /// <param name="userAgent">UserAgent</param>
        /// <param name="elapsedMs">UserAgent</param>
        /// <param name="user">用户</param>
        /// <param name="lbAppId">再使用负载均时，当前应用唯一编号</param>
        void LogVisit(string hostAddr, string hostName, string remoteAddr, string httpReferer, string httpMethod, string http, string requestUri, string userAgent, long elapsedMs, string lbAppId = null);
    }
}
