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
        /// 获取 流程线数据集
        /// </summary>
        public IQueryable<WorkFlowLine> FlowLines
        {
            get { return FlowLineRepository.Entities; }
        }

        #endregion

        #region 私有方法


        #endregion
    }
}
