using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;


namespace OSky.UI.Contracts
{
    public interface ITestContract : IScopeDependency
    {
        void Test();
    }
}
