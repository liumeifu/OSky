using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.ModelConfigurations.Flow
{
    public partial class WorkFlowItemConfiguration
    {
        partial void WorkFlowItemConfigurationAppend()
        {
            HasRequired(c => c.FlowDesign).WithRequiredPrincipal();
        }
    }
}
