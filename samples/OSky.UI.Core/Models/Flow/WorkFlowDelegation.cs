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
    /// 实体类——流程任务委托信息
    /// </summary>
    [Description("工作流-流程任务委托信息")]
    public class WorkFlowDelegation : EntityBase<Guid>, ICreatedAudited, ICreatedTime
    {
        /// <summary>
        /// 所属流程Id
        /// </summary>
        [Description("所属流程Id")]
        public Guid FlowDesignId { get; set; }
        /// <summary>
        /// 状态信息(0)
        /// </summary>
        [Description("状态信息")]
        public short Status { get; set; }
        /// <summary>
        /// 获取或设置 创建者Id
        /// </summary>
        [Required, StringLength(50), Description("创建者Id")]
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 获取或设置 创建者名称
        /// </summary>
        [Required, StringLength(50), Description("创建者名称")]
        public string CreatorUserName { get; set; }
        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        [Description("信息创建时间")]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 受托人Id
        /// </summary>
        [Required, StringLength(50), Description("受托人Id")]
        public string TrusteeId { get; set; }
        /// <summary>
        /// 获取或设置 创建者名称
        /// </summary>
        [Required, StringLength(50), Description("受托人名称")]
        public string TrusteeName { get; set; }
        /// <summary>
        /// 委托起始时间
        /// </summary>
        [Description("委托起始时间")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 委托结束时间
        /// </summary>
        [Description("委托结束时间")]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 流程信息
        /// </summary>
        public virtual WorkFlowDesign FlowDesign { get; set; }
    }
}
