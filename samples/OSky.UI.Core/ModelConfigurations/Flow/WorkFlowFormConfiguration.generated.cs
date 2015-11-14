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
    /// 实体类-数据表映射——WorkFlowForm
    /// </summary>
    public partial class WorkFlowFormConfiguration: EntityConfigurationBase<WorkFlowForm, Guid>
    { 
        /// <summary>
        /// 初始化一个<see cref="WorkFlowFormConfiguration"/>类型的新实例
        /// </summary>
        public WorkFlowFormConfiguration()
        {
            WorkFlowFormConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void WorkFlowFormConfigurationAppend();
    }
}
