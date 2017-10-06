using System.ComponentModel;

namespace Evol.TMovie.Domain.Models.Values
{
    public enum SourcePlatformType
    {
        [Description("微信")]
        WeChat = 0,

        [Description("支付宝")] 
        Alipay = 1
    }
}
