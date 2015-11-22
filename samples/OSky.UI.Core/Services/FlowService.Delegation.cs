using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Models.Flow;
using OSky.Utility.Data;
using OSky.UI.Dtos.Flow;
using OSky.Core.Data.Entity;

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
        /// 保存 流程委托数据
        /// </summary>
        /// <param name="dto">要添加的流程委托Dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult SaveDelegation(FlowDelegateDto dto)
        {
            if (dto.Id == Guid.Empty) {
                var model= dto.MapTo<WorkFlowDelegation>();
                model.Id = Guid.NewGuid();
                FlowDelegationRepository.Update(model);
                return new OperationResult(OperationResultType.Success, "更新 流程委托成功！");
            }
            var entity = dto.MapTo<WorkFlowDelegation>();
            FlowDelegationRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "添加 流程委托成功！");
        }

        #region 私有方法


        #endregion
    }
}
