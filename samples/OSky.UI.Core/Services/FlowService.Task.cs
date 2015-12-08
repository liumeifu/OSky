using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Models.Flow;
using OSky.UI.Dtos.Flow;
using OSky.Utility.Data;

namespace OSky.UI.Services
{
    public partial class FlowService
    {
        #region Implementation of IFlowContract
        /// <summary>
        /// 获取 流程任务数据集
        /// </summary>
        public IQueryable<WorkFlowTask> FlowTasks
        {
            get { return FlowTaskRepository.Entities; }
        }

        #endregion

        /// <summary>
        /// 获取 根据指定任务和用户的当前任务操作的状态dto
        /// </summary>
        /// <param name="dto">当前任务操作的状态dto</param>
        /// <param name="userId">当前用户Id</param>
        /// <returns>当前任务操作的状态dto</returns>
        public FlowProjectDto GetFlowOperateStatus(FlowProjectDto dto, Guid userId)
        {
            var currentTask = FlowTaskRepository.Entities.Where(c => c.Id == dto.TaskId).Select(m => new { m.Id,m.PrevId,m.StepId,m.Status,m.ReceiverId}).SingleOrDefault();
            FlowOperateStatusDto status = new FlowOperateStatusDto();
            if (currentTask == null)
            {
                status.HasSave = true;
                status.HasSumbit = true;
                status.HasBack = false;
                status.HasCallBack = false;
                status.HasAudit = false;
                status.HasAssign = false;
                status.IsCompleted = false;
                status.GroupTask = false;
            }
            else
            {
                var currentStep = FlowStepRepository.Entities.Where(c => c.FlowDesignId == dto.FlowId && c.StepId == currentTask.StepId).
                    Select(m => new {m.StepType,m.CountersignStrategy,m.CountersignPer,m.BackType }).SingleOrDefault();

                #region 根据任务状态判断任务可执行的操作
                if ((currentTask.Status == 1 || currentTask.Status == 2) && currentTask.ReceiverId == userId.ToString())
                {
                    //是否可结束流程
                    if (currentStep.StepType == 2)
                        status.IsCompleted = true;
                    else       //任务会审时判断是否需要选指定人
                    {
                        switch (currentStep.CountersignStrategy)
                        {
                            case 0:
                                int count = GetSiblingTask(dto.ItemId, currentTask.StepId).Where(c => c.Status < 10).Count();
                                if (count > 1)
                                    status.HasAudit = true;
                                else
                                    status.HasAssign = true;
                                break;
                            case 2:
                                decimal percentage = currentStep.CountersignPer <= 0 ? 100 : currentStep.CountersignPer;
                                IQueryable<WorkFlowTask> TaskQueryable = GetSiblingTask(dto.ItemId, currentTask.StepId).Where(c => c.PrevId == currentTask.PrevId);
                                if (Math.Round((((decimal)(TaskQueryable.Where(p => p.Status == 10).Count() + 1) / (decimal)TaskQueryable.Where(p => p.Status <= 10).Count()) * 100), 2, MidpointRounding.AwayFromZero) < percentage)
                                    status.HasAudit = true;
                                else
                                    status.HasAssign = true;
                                break;
                            default:
                                status.HasAssign = true;
                                break;
                        }
                    }

                    //是否可退回
                    if (currentStep.BackType == 0)
                        status.HasBack = false;
                    else
                        status.HasBack = true;
                }
                if (currentTask.ReceiverId == userId.ToString())
                {
                    //判断是否具有编辑表单的权限
                    if (currentTask.Id == currentTask.PrevId)
                        status.HasSave = true;
                    //判断任务是否可以撤销
                    OperationResult result = IsCallBack(dto.TaskId);
                    if (result.ResultType == OperationResultType.Success && currentTask.Id != currentTask.PrevId)
                        status.HasCallBack = true;
                    else
                        status.HasCallBack = false;
                }
                status.GroupTask = true;
                #endregion
            }
            dto.OperateStatus = status;
            return dto;
        }

        #region 私有方法

        /// <summary>
        /// 获取指定项 指定步骤的同级任务
        /// </summary>
        /// <param name="entityId">项目Id</param>
        /// <param name="stepId">步骤Id</param>
        /// <returns>找同级步骤未完成任务的查询结果集</returns>
        protected IQueryable<WorkFlowTask> GetSiblingTask(Guid itemId, short stepId)
        {
            return FlowTaskRepository.Entities.Where(c => c.FlowItemId == itemId && c.StepId == stepId);    //找同级步骤未完成的任务
        }
        /// <summary>
        /// 判断任务是否可撤销
        /// </summary>
        /// <param name="taskId">任务Id</param>
        /// <returns>业务操作结果</returns>
        protected OperationResult IsCallBack(Guid taskId)
        {
            var nextTask = FlowTaskRepository.Entities.Where(c => c.PrevId == taskId).Select(m => new { m.Id,m.Status}).ToList();
            if (nextTask.Count <= 0)
                return new OperationResult(OperationResultType.ValidError, "任务在下级已经有处理，不能再撤销！");
            else
            {
                foreach (var item in nextTask)
                {
                    if (item.Status != 1 )
                    {
                        return new OperationResult(OperationResultType.ValidError, "任务在下级已经有处理，不能再撤销！");
                    }
                }
            }

            return new OperationResult(OperationResultType.Success, "可以撤销处理", nextTask);
        }

        #endregion
    }
}
