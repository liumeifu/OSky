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
    /// 实体类——流程事项档案信息
    /// </summary>
    [Description("工作流-流程事项档案信息")]
    public class WorkFlowArchive : Entity<Guid>, ICreatedAudited, ICreatedTime
    {
        /// <summary>
        /// 流程事项Id
        /// </summary>
        [Description("流程事项Id")]
        public Guid FlowItemId { get; set; }
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
        /// 流程事项
        /// </summary>
        public virtual WorkFlowItem FlowItem { get; set; }
    }
}
