using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;

namespace OSky.UI.Dtos.Infos
{
    public class LeaveDto : IAddDto, IEditDto<Guid>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 获取或设置 请假类型值
        /// </summary>
        public string TypeVal { get; set; }
        /// <summary>
        /// 获取或设置 请假类型
        /// </summary>
        public string TypeHtml { get; set; }
        /// <summary>
        /// 获取或设置 请假类型
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 获取或设置 创建者Id
        /// </summary>
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 获取或设置 创建者
        /// </summary>
        public string CreatorUserName { get; set; }
        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 获取设置 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 获取设置 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
