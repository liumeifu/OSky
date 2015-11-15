using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;
using OSky.UI.Models.Flow;

namespace OSky.UI.Contracts
{
    /// <summary>
    /// 业务契约——工作流模块
    /// </summary>
    public interface IFlowContract:IScopeDependency
    {
        #region 流程设计
        /// <summary>
        /// 获取 流程设计数据集
        /// </summary>
        IQueryable<WorkFlowDesign> FlowDesigns { get; }

        #endregion

        #region 流程步骤
        /// <summary>
        /// 获取 流程步骤数据集
        /// </summary>
        IQueryable<WorkFlowStep> FlowSteps { get; }

        #endregion

        #region 流程线
        /// <summary>
        /// 获取 流程线数据集
        /// </summary>
        IQueryable<WorkFlowLine> FlowLines { get; }

        #endregion

        #region 流程事项
        /// <summary>
        /// 获取 流程事项数据集
        /// </summary>
        IQueryable<WorkFlowItem> FlowItems { get; }

        #endregion

        #region 流程任务
        /// <summary>
        /// 获取 流程任务数据集
        /// </summary>
        IQueryable<WorkFlowTask> FlowTasks { get; }

        #endregion

        #region 流程表单
        /// <summary>
        /// 获取 流程表单数据集
        /// </summary>
        IQueryable<WorkFlowForm> FlowForms { get; }

        #endregion

        #region 流程表单关联
        /// <summary>
        /// 获取 流程表单关联数据集
        /// </summary>
        IQueryable<WorkFlowRelateForm> FlowRelateForms { get; }

        #endregion

        #region 流程委托
        /// <summary>
        /// 获取 流程委托数据集
        /// </summary>
        IQueryable<WorkFlowDelegation> FlowDelegations { get; }

        #endregion

        #region 流程档案
        /// <summary>
        /// 获取 流程档案数据集
        /// </summary>
        IQueryable<WorkFlowArchive> FlowArchives { get; }

        #endregion
    }
}
