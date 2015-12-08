using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OSky.UI.Models.Infos
{
    public class Leave : EntityBase<Guid>, ICreatedAudited, ICreatedTime, ITimestamp
    {
        /// <summary>
        /// 获取或设置 请假类型
        /// </summary>
        [Required, StringLength(50), Description("请假类型")]
        public string Type { get; set; }
        /// <summary>
        /// 获取或设置 请假类型
        /// </summary>
        [Required, StringLength(200)]
        public string Reason { get; set; }
        /// <summary>
        /// 获取或设置 创建者Id
        /// </summary>
        [Required, StringLength(50), Description("创建者Id")]
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 获取设置 信息创建时间
        /// </summary>
        [Description("信息创建时间")]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 获取或设置 版本控制标识，用于处理并发
        /// </summary>
        [Description("并发效验")]
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
