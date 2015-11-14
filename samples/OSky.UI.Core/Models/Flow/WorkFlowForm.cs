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
    /// 实体类——流程表单信息
    /// </summary>
    [Description("工作流-流程表单信息")]
    public class WorkFlowForm : EntityBase<Guid>, ICreatedAudited, ICreatedTime
    {
        /// <summary>
        /// 表单名称
        /// </summary>
        [Required, StringLength(50), DisplayName("表单名称")]
        public string FormName { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        [Required, StringLength(50), DisplayName("表单类型")]
        public string Type { get; set; }
        /// <summary>
        /// 表单路径
        /// </summary>
        [Required, StringLength(200), DisplayName("表单路径")]
        public string FilePath { get; set; }
        /// <summary>
        /// 调用保存Action
        /// </summary>
        [Required, StringLength(200), DisplayName("调用保存Action")]
        public string ActionPath { get; set; }

        /// <summary>
        /// 是否配有流程
        /// </summary>
        [DisplayName("是否配有流程")]
        public bool EnabledFlow { get; set; }

        /// <summary>
        /// 状态信息：0 启用 1 停用
        /// </summary>
        [DisplayName("状态信息")]
        public short Status { get; set; }
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
    }
}
