using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Evol.TMovie.Domain.Models.Values
{

    /// <summary>
    /// 座位状态
    /// </summary>
    public enum SeatStatusType
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        [Display(Name = "启用")]
        Enabled = 0,

        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        [Display(Name = "禁用")]
        Disabled = 1
    }
}
