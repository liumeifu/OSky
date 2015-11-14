using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.Dtos.Flow
{
    /// <summary>
    /// 数据传输类——实体流程当前任务操作的状态dto
    /// </summary>
    public class FlowOperateStatusDto
    {
        /// <summary>
        /// 保存
        /// </summary>
        public bool HasSave { get; set; }
        /// <summary>
        /// 提交
        /// </summary>
        public bool HasSumbit { get; set; }
        /// <summary>
        /// 退回
        /// </summary>
        public bool HasBack { get; set; }
        /// <summary>
        /// 撤销
        /// </summary>
        public bool HasCallBack { get; set; }
        /// <summary>
        /// 审核
        /// </summary>
        public bool HasAudit { get; set; }
        /// <summary>
        /// 转派
        /// </summary>
        public bool HasAssign { get; set; }
        /// <summary>
        /// 完成
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// 流程记录
        /// </summary>
        public bool GroupTask { get; set; }
    }
}
