//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using log4net;

//namespace Evol.Web.Filters
//{
//    public class LogExceptionAttribute : HandleErrorAttribute
//    {
       
//        public override void OnException(ExceptionContext filterContext)
//        {
//            //var configPath = filterContext.HttpContext.Server.MapPath("~") + @"\log4net.config";
//            //var configFileInfo = new System.IO.FileInfo(configPath);
//            //var collection = log4net.Config.XmlConfigurator.Configure(configFileInfo);
//            ILog log = log4net.LogManager.GetLogger("logerror");
//            log.Error(filterContext.Exception.Message, filterContext.Exception);
//            filterContext.ExceptionHandled = true;
//            filterContext.Result = new ContentResult() {
//                Content = "发生了异常：" + DateTime.Now.ToString() + ", " + filterContext.Exception.Message,
//                ContentEncoding = Encoding.UTF8,
//                ContentType = "text/HTML"
//            };

//            if (!filterContext.ExceptionHandled)
//                base.OnException(filterContext);


//        }
//    }
//}
