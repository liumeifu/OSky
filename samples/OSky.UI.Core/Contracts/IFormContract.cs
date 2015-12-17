using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;
using OSky.UI.Models.Infos;
using OSky.Utility.Data;
using OSky.UI.Dtos.Infos;

namespace OSky.UI.Contracts
{
    /// <summary>
    /// 业务契约——表单模块
    /// </summary>
    public interface IFormContract : IScopeDependency
    {
        #region 请假单

        /// <summary>
        /// 获取 请假单数据集
        /// </summary>
        IQueryable<Leave> Leaves { get; }

         /// <summary>
        /// 添加 请假单数据
        /// </summary>
        /// <param name="dtos">要添加的请假单Dto</param>
        /// <returns>业务操作结果</returns>
        OperationResult AddLeave(params LeaveDto[] dtos);

        /// <summary>
        /// 更新 请假单数据
        /// </summary>
        /// <param name="dtos">要更新的请假单Dto</param>
        /// <returns>业务操作结果</returns>
        OperationResult EditLeave(params LeaveDto[] dtos);

        #endregion
    }
}
