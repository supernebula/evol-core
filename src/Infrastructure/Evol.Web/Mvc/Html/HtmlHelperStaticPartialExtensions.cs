using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Evol.Web.Mvc.Html
{
    public static class HtmlHelperStaticPartialExtensions
    {
        /// <summary>
        /// 指定静态（不包括任何服务端代码）的局部视图（包括文件扩展名）全名称，返回HTML标签格式内容
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="staticViewFullName">局部试图全名</param>
        /// <returns></returns>
        public static IHtmlContent HtmlPartial(this IHtmlHelper htmlHelper, string staticViewFullName)
        {
            var exeFilePath = htmlHelper.ViewContext.ExecutingFilePath;
            var exeFileDir = Path.GetDirectoryName(exeFilePath);
            var viewFullUri = Path.Combine(exeFileDir, staticViewFullName).Replace("\\", "/");
            return htmlHelper.Partial(viewFullUri);
        }
    }
}
