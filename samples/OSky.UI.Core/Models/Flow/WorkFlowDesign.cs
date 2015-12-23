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
    /// 实体类——流程设计信息
    /// </summary>
    [Description("工作流-流程设计信息")]
    public class WorkFlowDesign :Entity<Guid>, IAudited, ICreatedTime, ITimestamp
    {
        /// <summary>
        /// 初始化一个<see cref="WorkFlowDesign"/>类型的新实例
        /// </summary>
        public WorkFlowDesign()
        {
            Steps = new List<WorkFlowStep>();
            Lines = new List<WorkFlowLine>();
            Delegations = new List<WorkFlowDelegation>();
        }
        /// <summary>
        /// 流程类别
        /// </summary>
        [Required, StringLength(50), Description("流程类别")]
        public string FlowType{ get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        [Required, StringLength(200), Description("流程名称")]
        public string FlowName { get; set; }
        /// <summary>
        /// 流程xml信息
        /// </summary>
        [Required, Description("流程xml信息")]
        public string DesignInfo { get; set; }
        /// <summary>
        /// 状态信息
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
        /// 获取或设置 最后更新者Id
        /// </summary>
        [StringLength(50), Description("最后更新者Id")]
        public string LastUpdatorUserId { get; set; }
        /// <summary>
        /// 获取或设置 最后更新者名称
        /// </summary>
        [StringLength(50), Description("最后更新者名称")]
        public string LastUpdatorUserName { get; set; }
        /// <summary>
        /// 获取或设置 最后更新时间
        /// </summary>
        [Description("最后更新时间")]
        public DateTime? LastUpdatedTime { get; set; }
        /// <summary>
        /// 获取或设置 版本控制标识，用于处理并发
        /// </summary>
        [Description("并发效验")]
        [Timestamp]
        public byte[] Timestamp { get; set; }

        /// <summary>
        /// 流程步骤集
        /// </summary>
        public virtual ICollection<WorkFlowStep> Steps { get; set; }
        /// <summary>
        /// 流程线集
        /// </summary>
        public virtual ICollection<WorkFlowLine> Lines { get; set; }
        /// <summary>
        /// 流程委托集
        /// </summary>
        public virtual ICollection<WorkFlowDelegation> Delegations { get; set; }
    }
}
