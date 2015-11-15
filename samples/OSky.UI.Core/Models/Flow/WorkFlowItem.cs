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
    /// 实体类——流程事项信息
    /// </summary>
    [Description("工作流-流程事项信息")]
    public class WorkFlowItem : EntityBase<Guid>, ICreatedAudited, ICreatedTime
    {
        /// <summary>
        /// 初始化一个<see cref="WorkFlowItem"/>类型的新实例
        /// </summary>
        public WorkFlowItem()
        {
            //Tasks = new List<WorkFlowTask>();
            //Archives = new List<WorkFlowArchives>();
        }
        /// <summary>
        /// 所属流程Id
        /// </summary>
        [Description("所属流程Id")]
        public Guid FlowDesignId { get; set; }
        /// <summary>
        /// 流转实体ID
        /// </summary>
        [Description("流转实体ID")]
        public Guid EntityId { get; set; }
        /// <summary>
        /// 事项名称
        /// </summary>
        [Required, StringLength(100), Description("事项名称")]
        public string EntityName { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        [Description("完成时间")]
        public DateTime? CompletedTime { get; set; }
        /// <summary>
        /// 办理时限天数
        /// </summary>
        [Description("办理时限天数")]
        public short StepDay { get; set; }
        /// <summary>
        /// 延期天数
        /// </summary>
        [Description("延期天数")]
        public short DelayDay { get; set; }
        /// <summary>
        /// 处理天数
        /// </summary>
        [Description("处理天数")]
        public short HandleDay { get; set; }
        /// <summary>
        /// 状态信息（0 处理中 1 处理完成）
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
        /// 流程信息
        /// </summary>
        public virtual WorkFlowDesign FlowDesign { get; set; }
        /// <summary>
        /// 流程任务信息集
        /// </summary>
        public virtual ICollection<WorkFlowTask> Tasks { get; set; }
        /// <summary>
        /// 档案信息集
        /// </summary>
        public virtual ICollection<WorkFlowArchive> Archives { get; set; }
    }
}
