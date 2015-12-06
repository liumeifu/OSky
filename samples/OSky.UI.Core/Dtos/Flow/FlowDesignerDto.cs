using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;

namespace OSky.UI.Dtos.Flow
{
    /// <summary>
    /// 数据传输类——实体流程设计dto
    /// </summary>
    public class FlowDesignerDto : IAddDto, IEditDto<Guid>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 流程类别
        /// </summary>
        public string FlowType { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName { get; set; }
        /// <summary>
        /// 流程图信息
        /// </summary>
        public string DesignInfo { get; set; }
        /// <summary>
        /// 获取或设置 创建者名称
        /// </summary>
        public string CreatorUserName { get; set; }
        /// <summary>
        /// 表单Id
        /// </summary>
        public Guid FormId { get; set; }
    }
}
