
using System.ComponentModel;

namespace Evol.TMovie.Domain.Models.Values
{
    public enum OrderStatusType
    {
        [Description("已创建")]
        Created = 0,

        [Description("已支付")]
        Paid = 1,

        [Description("已签收")]
        Received = 2,

        [Description("已完成")]
        Completed = 3,

        [Description("已关闭")]
        Closed = 4
    }
}
