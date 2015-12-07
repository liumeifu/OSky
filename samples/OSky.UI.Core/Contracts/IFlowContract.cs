﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Dependency;
using OSky.UI.Models.Flow;
using OSky.Utility.Data;
using OSky.UI.Dtos.Flow;

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

        /// <summary>
        /// 保存 流程设计数据
        /// </summary>
        /// <param name="dto">要添加的流程设计Dto</param>
        /// <returns>业务操作结果</returns>
        OperationResult Save(FlowDesignerDto dto);

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

         /// <summary>
        /// 添加工作流表单信息
        /// </summary>
        /// <param name="dtos">要添加的表单信息dto</param>
        /// <returns>业务操作结果</returns>
        OperationResult AddFlowForm(params FlowFormDto[] dtos);

         /// <summary>
        /// 更新工作流表单信息
        /// </summary>
        /// <param name="dtos">包含更新的表单信息dto</param>
        /// <returns>业务操作结果</returns>
        OperationResult EditFlowForm(params FlowFormDto[] dtos);

        /// <summary>
        /// 删除工作流表单信息
        /// </summary>
        /// <param name="ids">工作流表单信息Id集合</param>
        /// <returns>业务操作结果</returns>
        OperationResult DeleteFlowForm(params Guid[] ids);

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

        /// <summary>
        /// 添加 流程委托数据
        /// </summary>
        /// <param name="dtos">要添加的流程委托Dto</param>
        /// <returns>业务操作结果</returns>
        OperationResult AddDelegation(params FlowDelegateDto[] dtos);

        /// <summary>
        /// 更新 流程委托数据
        /// </summary>
        /// <param name="dtos">包含更新的流程委托dto</param>
        /// <returns>业务操作结果</returns>
        OperationResult EditDelegation(params FlowDelegateDto[] dtos);

        #endregion

        #region 流程档案
        /// <summary>
        /// 获取 流程档案数据集
        /// </summary>
        IQueryable<WorkFlowArchive> FlowArchives { get; }

        #endregion
    }
}
