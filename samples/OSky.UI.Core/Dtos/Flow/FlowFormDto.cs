using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;

namespace OSky.UI.Dtos.Flow
{
    /// <summary>
    /// 数据传输类——实体表单dto
    /// </summary>
    public class FlowFormDto : IAddDto, IEditDto<Guid>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///  获取或设置 流程Id
        /// </summary>
        public Guid? FlowDesignId { get; set; }
        /// <summary>
        /// 表单名称
        /// </summary>
        public string FormName { get; set; }

        /// <summary>
        /// 表单类型值
        /// </summary>
        public string TypeVal { get; set; }

        /// <summary>
        /// 表单类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreatorUserName { get; set; }

        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        public DateTime CreatTime { get; set; }
        /// <summary>
        /// 表单路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 保存Action
        /// </summary>
        public string ActionPath { get; set; }
        /// <summary>
        /// 是否配有流程
        /// </summary>
        public bool EnabledFlow { get; set; }

        /// <summary>
        /// 状态信息：0 启用 1 停用
        /// </summary>
        public short Status { get; set; }
    }
}
