using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Models.Flow;

namespace OSky.UI.Services
{
    public partial class FlowService
    {
        #region Implementation of IFlowContract
        /// <summary>
        /// 获取 流程委托数据集
        /// </summary>
        public IQueryable<WorkFlowDelegation> FlowDelegations
        {
            get { return FlowDelegationRepository.Entities; }
        }

        #endregion

        #region 私有方法


        #endregion
    }
}
