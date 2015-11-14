using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.ModelConfigurations.Flow
{
    public partial class WorkFlowArchiveConfiguration
    {
        partial void WorkFlowArchiveConfigurationAppend()
        {
            HasRequired(c => c.FlowItem).WithMany(p => p.Archives).WillCascadeOnDelete();
        }
    }
}
