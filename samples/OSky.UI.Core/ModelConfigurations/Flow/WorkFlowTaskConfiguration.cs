using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.ModelConfigurations.Flow
{
    public partial class WorkFlowTaskConfiguration
    {
        partial void WorkFlowTaskConfigurationAppend()
        {
            HasRequired(c => c.FlowItem).WithMany(p => p.Tasks).WillCascadeOnDelete();
        }
    }
}
