using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Evol.Cinema.Domain.Models.Values
{
    /// <summary>
    /// 货物状态
    /// </summary>
    public enum GoodsStateType
    {
        /// <summary>
        /// 下架
        /// </summary>
        [Display(Name = "下架")]
        [Description("下架")]
        DownShelves,

        /// <summary>
        /// 预售
        /// </summary>
        [Display(Name = "预售")]
        [Description("预售")]
        PreSale,

        /// <summary>
        /// 上架
        /// </summary>
        [Display(Name = "上架")]
        [Description("上架")]
        UpShelves,

        /// <summary>
        /// 缺货
        /// </summary>
        [Display(Name = "缺货")]
        [Description("缺货")]
        Shortage
    }
}
