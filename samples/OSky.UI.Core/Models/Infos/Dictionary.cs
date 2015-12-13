using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OSky.UI.Models.Infos
{
    /// <summary>
    /// 实体类——系统管理数据字典
    /// </summary>
    [Description("系统管理-数据字典")]
    public class Dictionary : EntityBase<int>
    {
        /// <summary>
        /// 初始化一个<see cref="Dictionary"/>类型的新实例
        /// </summary>
        public Dictionary()
        {
            Children = new List<Dictionary>();
        }
        /// <summary>
        /// 父级Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Required, StringLength(50)]
        public string Value { get; set; }

        /// <summary>
        /// 获取或设置 排序码
        /// </summary>
        [Range(0, 999)]
        public int SortCode { get; set; }

        /// <summary>
        /// 获取或设置 父级组织机构信息
        /// </summary>
        public virtual Dictionary Parent { get; set; }

        /// <summary>
        /// 获取或设置 子级组织机构信息集合
        /// </summary>
        public virtual ICollection<Dictionary> Children { get; set; }
    }
}
