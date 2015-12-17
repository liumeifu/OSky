using OSky.Core.Data.Entity;
using OSky.UI.Models.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.ModelConfigurations.Infos
{
    /// <summary>
    /// 实体类-数据表映射——Leave
    /// </summary> 
    public class LeaveConfiguration : EntityConfigurationBase<Leave, Guid>
    {
        /// <summary>
        /// 初始化一个<see cref="LeaveConfiguration"/>类型的新实例
        /// </summary>
        public LeaveConfiguration()
        {
            LeaveConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        void LeaveConfigurationAppend()
        {
            
        }
    }
}
