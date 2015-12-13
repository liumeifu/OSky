using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.Dtos.Flow
{
    /// <summary>
    /// 数据传输类——流转信息dto
    /// </summary>
    public class FlowExecuteFormDto
    {
        public FlowExecuteFormDto()
        {
            StepToUsers = new List<StepToUser>();
        }
        /// <summary>
        /// 流程Id
        /// </summary>
        public Guid FlowId { get; set; }
        /// <summary>
        /// 任务Id
        /// </summary>
        public Guid TaskId { get; set; }
        /// <summary>
        /// 流程项Id
        /// </summary>
        public Guid ItemId { get; set; }

        /// <summary>
        /// 会签类型（0：无签批意见栏 1：有签批意见栏 2：有签批意见栏且需要盖章）
        /// </summary>
        public int CountersignType { get; set; }
        /// <summary>
        /// 任务说明
        /// </summary>
        public string TaskNote { get; set; }

        /// <summary>
        /// 指定步骤对应处理人集合
        /// </summary>
        public List<StepToUser> StepToUsers { get; set; }

    }
    /// <summary>
    /// 指定步骤对应处理人集合
    /// </summary>
    public class StepToUser
    {
        /// <summary>
        /// 步骤Id
        /// </summary>
        public int StepId { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// 处理人Id多人逗号分隔
        /// </summary>
        public string HandlerIds { get; set; }
        /// <summary>
        /// 处理人姓名多人逗号分隔
        /// </summary>
        public string HandlerNames { get; set; }

    }
}
