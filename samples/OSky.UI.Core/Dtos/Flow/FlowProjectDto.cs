using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.Dtos.Flow
{
    /// <summary>
    /// 数据传输类——实体流转信息dto
    /// </summary>
    public class FlowProjectDto
    {
        /// <summary>
        /// 实体ID
        /// </summary>
        public Guid EntityId { get; set; }
        /// <summary>
        /// 流程ID
        /// </summary>
        public Guid FlowId { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public Guid TaskId { get; set; }
        /// <summary>
        /// 事项ID
        /// </summary>
        public Guid ItemId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 表单Html路径
        /// </summary>
        public string FileUrl { get; set; }
        /// <summary>
        /// 表单提交Action路径
        /// </summary>
        public string ActionUrl { get; set; }

        /// <summary>
        /// 任务操作的状态dto
        /// </summary>
        public FlowOperateStatusDto OperateStatus { get; set; }
    }
}
