using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.UI.Models.Infos;
using OSky.Utility.Data;
using OSky.UI.Dtos.Infos;
using OSky.UI.Contracts;

namespace OSky.UI.Services
{
    /// <summary>
    /// 业务实现——表单模块
    /// </summary>
    public class FormService : IFormContract
    {
        #region 请假单

        /// <summary>
        /// 获取或设置 请假单信息仓储操作对象
        /// </summary>
        public IRepository<Leave, Guid> LeaveRepository { protected get; set; }

        /// <summary>
        /// 获取 请假单数据集
        /// </summary>
        public IQueryable<Leave> Leaves { get; set; }

        /// <summary>
        /// 添加 请假单数据
        /// </summary>
        /// <param name="dtos">要添加的请假单Dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddLeave(params LeaveDto[] dtos)
        {
            return LeaveRepository.Insert(dtos);
        }

        /// <summary>
        /// 更新 请假单数据
        /// </summary>
        /// <param name="dtos">要更新的请假单Dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditLeave(params LeaveDto[] dtos)
        {
            return LeaveRepository.Update(dtos);
        }

        #endregion

    }
}
