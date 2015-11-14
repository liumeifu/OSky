using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.Dtos.Flow
{
    /// <summary>
    /// 数据传输类——流程表单关联dto
    /// </summary>
    public class FlowRelateFormDto
    {
        /// </summary>
        /// 表单名称
        /// </summary>
        public string FormName { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 表单路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 保存Action
        /// </summary>
        public string ActionPath { get; set; }
       
        /// <summary>
        /// 状态信息：0 启用 1 停用
        /// </summary>
        public short Status { get; set; }
        /// <summary>
        /// 是否配有流程
        /// </summary>
        public bool EnabledFlow { get; set; }
        /// <summary>
        /// 获取或设置 创建者名称
        /// </summary>
        public string CreatorUserName { get; set; }
        /// <summary>
        /// 获取或设置 最后更新者名称
        /// </summary>
        public string LastUpdatorUserName { get; set; }
        /// <summary>
        /// 所属流程Id
        /// </summary>
        public Guid FlowDesignId { get; set; }
        /// <summary>
        /// 表单信息Id
        /// </summary>
        public Guid FlowFormId { get; set; }
    }
}
