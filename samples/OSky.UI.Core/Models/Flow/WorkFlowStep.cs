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
    /// 实体类——流程步骤信息
    /// </summary>
    [Description("工作流-流程步骤信息")]
    public class WorkFlowStep : EntityBase<Guid>
    {
        /// <summary>
        /// 所属流程Id
        /// </summary>
        [Description("所属流程Id")]
        public Guid FlowDesignId { get; set; }
        /// <summary>
        /// 步骤Id
        /// </summary>
        [Description("步骤Id")]
        public short StepId { get; set; }

        /// <summary>
        /// 步骤类别（0：起始步骤 1：中间步骤 2：结束步骤）
        /// </summary>
        [Description("步骤类别")]
        public short StepType { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
        [StringLength(50), Description("步骤名称")]
        public string StepName { get; set; }

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
        /// 步骤期限时间（-1 无限 0 即时办理）
        /// </summary>
        [Description("步骤期限时间")]
        public short SpecifiedDay { get; set; }

        /// <summary>
        /// 本步骤是否归档（1：流程归档 0：不归档）
        /// </summary>
        [Description("本步骤是否归档")]
        public bool IsArchives { get; set; }
        /// <summary>
        /// 步骤说明
        /// </summary>
        [Description("步骤说明")]
        public string StepDescription { get; set; }

        public virtual WorkFlowDesign FlowDesign { get; set; }
    }
}
