using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data.Entity;
using OSky.UI.Models.Infos;

namespace OSky.UI.ModelConfigurations.Infos
{
    /// <summary>
    /// 实体类-数据表映射——Dictionary
    /// </summary> 
    public class DictionaryConfiguration : EntityConfigurationBase<Dictionary, Int32>
    {
        /// <summary>
        /// 初始化一个<see cref="DictionaryConfiguration"/>类型的新实例
        /// </summary>
        public DictionaryConfiguration()
        {
            DictionaryConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        void DictionaryConfigurationAppend()
        {
            HasOptional(m => m.Parent).WithMany(n => n.Children);
        }
    }
}
