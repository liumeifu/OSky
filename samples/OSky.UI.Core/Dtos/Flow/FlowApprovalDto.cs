using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.Dtos.Flow
{
    public class FlowApprovalDto
    {
        /// <summary>
        /// 当前步骤名称
        /// </summary>
        public string FlowItemId { get; set; }
        /// <summary>
        /// 当前步骤名称
        /// </summary>
        public string StepName { get; set; }
        /// <summary>
        /// 发送人
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        public string ReceiverName { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? CompletedTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 意见
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string TaskNote { get; set; }
    }
}
