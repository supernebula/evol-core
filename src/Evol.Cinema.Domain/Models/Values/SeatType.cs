using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Evol.TMovie.Domain.Models.Values
{
    /// <summary>
    /// 座位类型
    /// </summary>
    public enum SeatType
    {
        /// <summary>
        /// 单人座
        /// </summary>
        [Description("单人座")]
        [Display(Name = "单人座")]
        NormalSeat = 0,

        /// <summary>
        /// 情侣座
        /// </summary>
        [Description("情侣座")]
        [Display(Name = "情侣座")]
        LoveSeat = 1
    }
}
