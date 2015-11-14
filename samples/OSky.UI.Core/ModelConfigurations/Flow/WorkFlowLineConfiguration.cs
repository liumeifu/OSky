using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.ModelConfigurations.Flow
{
    public partial class WorkFlowLineConfiguration
    {
        partial void WorkFlowLineConfigurationAppend()
        {
            HasRequired(c => c.FlowDesign).WithMany(p => p.Lines).WillCascadeOnDelete();
        }
    }
}
