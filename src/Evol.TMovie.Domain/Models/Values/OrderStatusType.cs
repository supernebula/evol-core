
using System.ComponentModel;

namespace Evol.TMovie.Domain.Models.Values
{
    public enum OrderStatusType
    {
        [Description("已创建")]
        Created,

        [Description("已支付")]
        Paid,

        [Description("已完成")]
        Completed,

        [Description("已关闭")]
        Closed
    }
}
