using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OSky.Core.Data;

namespace OSky.UI.Models.Flow
{
    /// <summary>
    /// 实体类——表单流程关联信息
    /// </summary>
    [Description("工作流-表单流程关联信息")]
    public class WorkFlowRelateForm : EntityBase<Guid>, IAudited, ICreatedTime
    {
        /// <summary>
        /// 所属流程Id
        /// </summary>
        [Display(Name = "所属流程Id")]
        public Guid FlowDesignId { get; set; }
        /// <summary>
        /// 表单信息Id
        /// </summary>
        [Display(Name = "表单信息Id")]
        public Guid FlowFormId { get; set; }
        /// <summary>
        /// 状态信息：0 启用 1 停用
        /// </summary>
        [DisplayName("状态信息")]
        public short Status { get; set; }
        /// <summary>
        /// 获取或设置 创建者Id
        /// </summary>
        [Required, StringLength(50), Description("创建者Id")]
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        [Description("信息创建时间")]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 获取或设置 最后更新者Id
        /// </summary>
        [StringLength(50), Description("最后更新者Id")]
        public string LastUpdatorUserId { get; set; }
        /// <summary>
        /// 获取或设置 最后更新时间
        /// </summary>
        [Description("最后更新时间")]
        public DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// 流程信息
        /// </summary>
        public virtual WorkFlowDesign FlowDesign { get; set; }
        /// <summary>
        /// 表单信息
        /// </summary>
        public virtual WorkFlowForm FlowForm { get; set; }
    }
}
