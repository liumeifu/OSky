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
    /// 实体类——流程线
    /// </summary>
    [Description("工作流-流程线")]
    public class WorkFlowLine : EntityBase<Guid>
    {
        /// <summary>
        /// 所属流程Id
        /// </summary>
        [Description("所属流程Id")]
        public Guid FlowDesignId { get; set; }
        /// <summary>
        /// 当前步骤Id
        /// </summary>
        [Description("当前步骤Id")]
        public short FromStepId { get; set; }
        /// <summary>
        /// 当前步骤名称
        /// </summary>
        [Required, StringLength(50), Description("当前步骤名称")]
        public string FromStepName { get; set; }
        /// <summary>
        /// 下一步骤Id
        /// </summary>
        [Description("下一步骤Id")]
        public short ToStepId { get; set; }
        /// <summary>
        /// 下一步骤名称
        /// </summary>
        [Required, StringLength(50), Description("下一步骤名称")]
        public string ToStepName { get; set; }
        /// <summary>
        /// 前端处理方法
        /// </summary>
        [StringLength(4000), Description("前端处理方法")]
        public string CustomMethod { get; set; }
        /// <summary>
        /// 数据库执行sql
        /// </summary>
        [StringLength(4000), Description("数据库执行sql")]
        public string Sql { get; set; }

        /// <summary>
        /// 默认处理人Id,多人逗号分隔
        /// </summary>
        [StringLength(500), Description("默认处理人Id")]
        public string HandlerIds { get; set; }
        /// <summary>
        /// 默认处理人名称,多人逗号分隔
        /// </summary>
        [StringLength(500), Description("默认处理人名称")]
        public string HandlerNames { get; set; }
        /// <summary>
        /// 流程信息
        /// </summary>
        public virtual WorkFlowDesign FlowDesign { get; set; }
    }
}
