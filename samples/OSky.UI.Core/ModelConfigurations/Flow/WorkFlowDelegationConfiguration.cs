using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.ModelConfigurations.Flow
{
    public partial class WorkFlowDelegationConfiguration
    {
        partial void WorkFlowDelegationConfigurationAppend()
        {
            HasRequired(c => c.FlowDesign).WithMany(p => p.Delegations).WillCascadeOnDelete();
        }
    }
}
