﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.ModelConfigurations.Flow
{
    public partial class WorkFlowRelateFormConfiguration
    {
        partial void WorkFlowRelateFormConfigurationAppend()
        {
            HasRequired(c => c.FlowForm).WithMany();
            HasRequired(c => c.FlowDesign).WithMany();
        }
    }
}
