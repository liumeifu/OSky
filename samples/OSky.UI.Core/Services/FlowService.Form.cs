using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Models.Flow;
using OSky.Utility.Data;

namespace OSky.UI.Services
{
    public partial class FlowService
    {
        #region Implementation of IFlowContract
        /// <summary>
        /// 获取 流程表单数据集
        /// </summary>
        public IQueryable<WorkFlowForm> FlowForms
        {
            get { return FlowFormRepository.Entities; }
        }

        #endregion

        #region 私有方法
        /// <summary>
        ///  更新 流程设计表单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private OperationResult UpdateWorkFlowForm(Guid id)
        {
            OperationResult result = new OperationResult(OperationResultType.NoChanged, "更新流程设计表单失败！");
            var entity = FlowFormRepository.GetByKey(id);
            entity.EnabledFlow = true;
            FlowFormRepository.Update(entity);
            result = new OperationResult(OperationResultType.Success, "更新 流程设计表单成功！");
            return result;
        }

        #endregion
    }
}
