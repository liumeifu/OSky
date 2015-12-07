using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;

namespace OSky.UI.Dtos.Flow
{
    /// <summary>
    /// 数据传输类——实体委托dto
    /// </summary>
    public class FlowDelegateDto : IAddDto, IEditDto<Guid>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 需要委托的流程Id
        /// </summary>
        public Guid FlowDesignId { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName { get; set; }
        /// <summary>
        /// 委托人Id
        /// </summary>
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 委托人
        /// </summary>
        public string CreatorUserName { get; set; }
        /// <summary>
        /// 受托人Id
        /// </summary>
        public string TrusteeId { get; set; }
        /// <summary>
        /// 受托人
        /// </summary>
        public string TrusteeName { get; set; }
        /// <summary>
        /// 委托起始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 委托结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 状态信息：0 启用 1 停用
        /// </summary>
        public short Status { get; set; }
    }
}
