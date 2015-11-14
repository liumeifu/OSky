using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data.Entity;
using OSky.UI.Models.Flow;

namespace OSky.UI.ModelConfigurations.Flow
{
    /// <summary>
    /// 实体类-数据表映射——WorkFlowItem
    /// </summary>
    public partial class WorkFlowItemConfiguration : EntityConfigurationBase<WorkFlowItem, Guid>
    { 
        /// <summary>
        /// 初始化一个<see cref="WorkFlowItemConfiguration"/>类型的新实例
        /// </summary>
        public WorkFlowItemConfiguration()
        {
            WorkFlowItemConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void WorkFlowItemConfigurationAppend();
    }
}
