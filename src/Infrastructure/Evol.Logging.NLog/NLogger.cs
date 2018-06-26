﻿using System;
using Evol.Common.Logging;
using NLog;

namespace Evol.Logging.AdapteNLog
{
    public class NLogger : Common.Logging.ILogger
    {
        private NLog.Logger _nlog;
        public NLogger(NLog.Logger logger)
        {
            _nlog = logger; 
        }

        #region LogCritical

        [Obsolete("预留暂不实现")]
        public void LogCritical(Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        [Obsolete("预留暂不实现")]
        public void LogCritical(EventId eventId, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        [Obsolete("预留暂不实现")]
        public void LogCritical(EventId eventId, Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        [Obsolete("预留暂不实现")]
        public void LogCritical(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void LogData<T>(T model)
        {
            var propValues = DictionaryObjectConvert.DictionarySimpleContractConvert(model);
            var logEventInfo = LogEventInfo.Create(LogLevel.Info, _nlog.Name, $"{typeof(T)}_数据库日志");
            foreach (var prop in propValues)
            {
                logEventInfo.Properties[prop.Key] = prop.Value;
            }
            _nlog.Log(logEventInfo);
        }



        public void LogDebug(EventId eventId, Exception exception, string message, params object[] args)
        {
            _nlog.Debug(exception, $"eventId:{eventId} | message:{message}", args);
        }

        public void LogDebug(EventId eventId, string message, params object[] args)
        {
            _nlog.Debug($"eventId:{eventId} | message:{message}", args);
        }

        public void LogDebug(Exception exception, string message, params object[] args)
        {
            _nlog.Debug(exception, message, args);
        }

        public void LogDebug(string message, params object[] args)
        {
            _nlog.Debug(message, args);
        }

        public void LogError(EventId eventId, Exception exception, string message, params object[] args)
        {
            _nlog.Error(exception, $"eventId:{eventId} | message:{message}", args);
        }

        public void LogError(EventId eventId, string message, params object[] args)
        {
            _nlog.Error($"eventId:{eventId} | message:{message}", args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            _nlog.Error(exception, message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _nlog.Debug(message, args);
        }

        public void LogInformation(EventId eventId, Exception exception, string message, params object[] args)
        {
            _nlog.Info(exception, $"eventId:{eventId} | message:{message}", args);
        }

        public void LogInformation(EventId eventId, string message, params object[] args)
        {
            _nlog.Info($"eventId:{eventId} | message:{message}", args);
        }

        public void LogInformation(Exception exception, string message, params object[] args)
        {
            _nlog.Info(exception, message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _nlog.Info(message, args);
        }

        public void LogTrace(EventId eventId, Exception exception, string message, params object[] args)
        {
            _nlog.Trace(exception, $"eventId:{eventId} | message:{message}", args);
        }

        public void LogTrace(Exception exception, string message, params object[] args)
        {
            _nlog.Trace(exception, message, args);
        }

        public void LogTrace(string message, params object[] args)
        {
            _nlog.Trace(message, args);
        }

        public void LogTrace(EventId eventId, string message, params object[] args)
        {
            _nlog.Trace($"eventId:{eventId} | message:{message}", args);
        }

        public void LogWarning(EventId eventId, Exception exception, string message, params object[] args)
        {
            _nlog.Warn(exception, $"eventId:{eventId} | message:{message}", args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _nlog.Trace(message, args);
        }

        public void LogWarning(EventId eventId, string message, params object[] args)
        {
            _nlog.Warn($"eventId:{eventId} | message:{message}", args);
        }

        public void LogWarning(Exception exception, string message, params object[] args)
        {
            if (exception != null)
                message += $"\r\n  exception:{exception.Message}, \r\n InnerException:{exception?.InnerException.Message} \r\n StackTrace:{exception.StackTrace}";
            _nlog.Warn(exception, message, args);
        }

        internal void Log(LogEventInfo logEvent)
        {
            _nlog.Log(logEvent);
        }

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
        public void LogBasicOperate(BasicOperateLogType operateType, string remoteAddr, string host, string original, string current, string remark, string operatorId, string operatorName, object logLevel = null)
        {
            LogEventInfo logEvent = new LogEventInfo(logLevel as LogLevel ?? LogLevel.Info, "", operateType.ToString());
            logEvent.Properties["id"] = Guid.NewGuid().ToString();
            logEvent.Properties["operateType"] = operateType;
            logEvent.Properties["remoteAddr"] = remoteAddr;
            logEvent.Properties["host"] = host;
            logEvent.Properties["original"] = original;
            logEvent.Properties["current"] = current;
            logEvent.Properties["remark"] = remark;
            logEvent.Properties["operatorId"] = operatorId;
            logEvent.Properties["operatorName"] = operatorName;
            Log(logEvent);
        }

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
        public void LogVisit(string hostAddr, string hostName, string remoteAddr, string httpReferer, string httpMethod, string http, string requestUri, string userAgent, long elapsedMs)
        {
            LogEventInfo logEvent = new LogEventInfo();
            logEvent.Properties["id"] = Guid.NewGuid().ToString();
            logEvent.Properties["hostAddr"] = hostAddr;
            logEvent.Properties["hostName"] = hostName;
            logEvent.Properties["RemoteAddr"] = remoteAddr;
            logEvent.Properties["httpReferer"] = httpReferer;
            logEvent.Properties["method"] = httpMethod;
            logEvent.Properties["http"] = http;
            logEvent.Properties["requestUri"] = requestUri;
            logEvent.Properties["userAgent"] = userAgent;
            logEvent.Properties["Time"] = DateTime.Now;
            Log(logEvent);
        }


    }
}
