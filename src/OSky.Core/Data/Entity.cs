using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace OSky.Core.Data
{
    /// <summary>
    /// 可持久化到数据库的数据模型基类(主键设为不自增)
    /// </summary>
    /// <typeparam name="TKey">主键数据类型</typeparam>
    public abstract class Entity<TKey> : EntityBase<TKey> 
    {
        #region 属性

        /// <summary>
        /// 获取或设置 实体唯一标识，主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("主键")]
        public override TKey Id { get; set; }

        #endregion
    }
}
