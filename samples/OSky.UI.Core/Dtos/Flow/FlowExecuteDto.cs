using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.Dtos.Flow
{
    public class FlowExecuteDto
    {
        public FlowExecuteDto()
        {
            Steps = new Dictionary<int, Dictionary<string, string>>();
        }
        /// <summary>
        /// 流程ID
        /// </summary>
        public Guid FlowId { get; set; }
        /// <summary>
        /// 实体Id
        /// </summary>
        public Guid EntityId { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public Guid TaskId { get; set; }
        /// <summary>
        /// 流程项Id
        /// </summary>
        public Guid ItemId { get; set; }
        /// <summary>
        /// 实例名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public ExecuteType ExecuteType { get; set; }
        /// <summary>
        /// 发送人员Id
        /// </summary>
        public string SenderId { get; set; }
        /// <summary>
        /// 发送人员名称
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 接收的步骤Id和人员Id
        /// </summary>
        public Dictionary<int, Dictionary<string,string>> Steps { get; set; }
        /// <summary>
        /// 处理意见
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 是否签章
        /// </summary>
        public bool IsSeal { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
    /// <summary>
    /// 处理类型
    /// </summary>
    public enum ExecuteType
    {
        /// <summary>
        /// 保存
        /// </summary>
        Save,
        /// <summary>
        /// 提交
        /// </summary>
        Submit,
        /// <summary>
        /// 退回
        /// </summary>
        Back,
        /// <summary>
        /// 完成
        /// </summary>
        Completed,
        /// <summary>
        /// 撤销
        /// </summary>
        CallBack
    }
}
