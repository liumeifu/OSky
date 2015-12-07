using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Utility.Data;
using OSky.UI.Models.Flow;
using OSky.UI.Dtos.Flow;
using OSky.Utility.Extensions;

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

        /// <summary>
        /// 添加 流程委托数据
        /// </summary>
        /// <param name="dtos">要添加的流程委托Dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddDelegation(params FlowDelegateDto[] dtos)
        {
            return FlowDelegationRepository.Insert(dtos, dto =>
            {
                if (FlowDelegationRepository.CheckExists(m => m.FlowDesignId == dto.FlowDesignId && m.CreatorUserId==dto.CreatorUserId && m.Status == 0))
                {
                    throw new Exception("名称为“{0}”的委托信息已存在，不能重复添加。".FormatWith(dto.FlowName));
                }
            });
        }

        /// <summary>
        /// 更新 流程委托数据
        /// </summary>
        /// <param name="dtos">包含更新的流程委托dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditDelegation(params FlowDelegateDto[] dtos)
        {
            return FlowDelegationRepository.Update(dtos, null, null);
        }

        #region 私有方法


        #endregion
    }
}
