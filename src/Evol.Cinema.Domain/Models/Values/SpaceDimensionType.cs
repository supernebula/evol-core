using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Evol.TMovie.Domain.Models.Values
{
    /// <summary>
    /// 空间维度类型
    /// </summary>
    public enum SpaceDimensionType
    {
        /// <summary>
        /// 2D
        /// </summary>
        [Description("2D")]
        [Display(Name = "2D")]
        Movie2D = 0,

        /// <summary>
        /// 3D
        /// </summary>
        [Description("3D")]
        [Display(Name = "3D")]
        Movie3D = 1,

        /// <summary>
        /// 4D
        /// </summary>
        [Description("4D")]
        [Display(Name = "4D")]
        Movie4D = 2,

        /// <summary>
        /// 5D
        /// </summary>
        [Description("5D")]
        [Display(Name = "5D")]
        Movie5D = 3
    }
}
