using System.ComponentModel;

namespace Evol.Fx.Web.Filters
{
    public enum ApiReponseStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 0,

        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = 1
    }


    public class ApiReponseBaseModel
    {
        public ApiReponseStatus Success { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }
    }
}
