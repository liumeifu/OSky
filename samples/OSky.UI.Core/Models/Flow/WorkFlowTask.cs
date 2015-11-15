using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OSky.Core.Data;

namespace OSky.UI.Models.Flow
{
    /// <summary>
    /// 实体类——流程任务信息
    /// </summary>
    [Description("工作流-流程任务信息")]
    public class WorkFlowTask : EntityBase<Guid>, ICreatedTime, ITimestamp
    {
        /// <summary>
        /// 上级任务Id
        /// </summary>
        [Description("上级任务Id")]
        public Guid PrevId { get; set; }
        /// <summary>
        /// 流程事项Id
        /// </summary>
        [Description("流程事项Id")]
        public Guid FlowItemId { get; set; }
        /// <summary>
        /// 上一步骤Id
        /// </summary>
        [Description("上一步骤Id")]
        public short PrevStepId { get; set; }
        /// <summary>
        /// 当前步骤Id
        /// </summary>
        [Description("当前步骤Id")]
        public short StepId { get; set; }
        /// <summary>
        /// 当前步骤名称
        /// </summary>
        [Required, StringLength(50), Description("当前步骤名称")]
        public string StepName { get; set; }
        /// <summary>
        /// 发送人Id
        /// </summary>
        [Required, StringLength(50), Description("发送人Id")]
        public string SenderId { get; set; }
        /// <summary>
        /// 发送人名称
        /// </summary>
        [Required, StringLength(50), Description("发送人名称")]
        public string SenderName { get; set; }
        /// <summary>
        /// 接收人Id
        /// </summary>
        [Required, StringLength(50), Description("接收人Id")]
        public string ReceiverId { get; set; }
        /// <summary>
        /// 接收人名称
        /// </summary>
        [Required, StringLength(50), Description("接收人名称")]
        public string ReceiverName { get; set; }
        /// <summary>
        /// 打开时间
        /// </summary>
        [Description("打开时间")]
        public DateTime? OpenedTime { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        [Description("完成时间")]
        public DateTime? CompletedTime { get; set; }
        /// <summary>
        /// 审批意见
        /// </summary>
        [StringLength(200), Description("审批意见")]
        public string Comment { get; set; }
        /// <summary>
        /// 会签类型（0：无签批意见栏 1：有签批意见栏 2：有签批意见栏且需要盖章）
        /// </summary>
        [Description("步骤类别")]
        public short CountersignType { get; set; }
        /// <summary>
        /// 会签策略（0：所有步骤同意 1：一人同意即可 2:比例同意即可）
        /// </summary>
        [Description("会签策略")]
        public short CountersignStrategy { get; set; }
        /// <summary>
        /// 会签通过比例
        /// </summary>
        [Description("会签通过比例")]
        public short CountersignPer { get; set; }
        /// <summary>
        /// 退回类型（0：无退回 1:退回到上一步，2：退回到第一步，3：退回到指定步骤）
        /// </summary>
        [Description("退回类型")]
        public short BackType { get; set; }
        /// <summary>
        /// 指定退回步骤名称
        /// </summary>
        [StringLength(50), Description("指定退回步骤名称")]
        public string SpecifiedBackStep { get; set; }
        /// <summary>
        /// 本步骤是否归档（1：流程归档 0：不归档）
        /// </summary>
        [Description("本步骤是否归档")]
        public bool IsArchives { get; set; }
        /// <summary>
        /// 任务说明
        /// </summary>
        [StringLength(50), Description("任务说明")]
        public string TaskNote { get; set; }
        /// <summary>
        /// 时限天数
        /// </summary>
        [Description("时限天数")]
        public short StepDay { get; set; }
        /// <summary>
        /// 办理天数
        /// </summary>
        [Description("办理天数")]
        public short HandleDay { get; set; }
        /// <summary>
        /// 延期天数
        /// </summary>
        [Description("延期天数")]
        public short DelayDay { get; set; }
        /// <summary>
        /// 申请延期事由
        /// </summary>
        [StringLength(200), Description("申请延期事由")]
        public string DelayReason { get; set; }
        /// <summary>
        /// 状态信息(1：待处理，2：已打开，10：正常办结，20：已退回，30：他人处理，40：他人退回，50：其他)
        /// </summary>
        [Description("状态信息")]
        public short Status { get; set; }
        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        [Description("信息创建时间")]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 获取或设置 版本控制标识，用于处理并发
        /// </summary>
        [Description("并发效验")]
        [Timestamp]
        public byte[] Timestamp { get; set; }
        /// <summary>
        /// 流程事项信息
        /// </summary>
        public virtual WorkFlowItem FlowItem { get; set; }
        /// <summary>
        /// 流程任务信息
        /// </summary>
        [ForeignKey("PrevId")]
        public virtual WorkFlowTask PrevFlowTask { get; set; }
    }
}
