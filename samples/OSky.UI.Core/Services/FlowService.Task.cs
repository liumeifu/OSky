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
        public FlowProjectDto GetFlowOperateStatus(FlowProjectDto dto, string userId)
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
                if ((currentTask.Status == 1 || currentTask.Status == 2) && currentTask.ReceiverId == userId)
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
                if (currentTask.ReceiverId == userId)
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

        /// <summary>
        /// 执行 根据指定任务 标识已阅读
        /// </summary>
        /// <param name="taskId">流程任务Id</param>
        /// <returns>业务操作结果</returns>
        public OperationResult OpenTask(Guid TaskId)
        {
            OperationResult re = new OperationResult(OperationResultType.NoChanged);
            var currentTask = FlowTaskRepository.Entities.SingleOrDefault(c => c.Id == TaskId);
            if (currentTask != null && currentTask.Status == 1)
            {
                currentTask.Status = 2;
                currentTask.OpenedTime = DateTime.Now;
                FlowTaskRepository.Update(currentTask);
                re = new OperationResult(OperationResultType.Success, "任务已阅读");
            }
            return re;
        }

        /// <summary>
        /// 提交任务
        /// </summary>
        /// <param name="task">当前任务Dto</param>
        /// <returns>业务操作结果</returns>
        protected OperationResult ExecuteSubmit(FlowExecuteDto task)
        {
            OperationResult re = new OperationResult(OperationResultType.Success, "处理成功!");
            WorkFlowTask currentTask = FlowTaskRepository.Entities.SingleOrDefault(c => c.Id == task.TaskId);

            if (currentTask == null)
            {
                return CreateFirstTask(task);
            }

            var currentStep = FlowStepRepository.Entities.Where(c => c.FlowDesignId == task.FlowId && c.StepId == currentTask.StepId).
                Select(m => new {m.StepType,m.CountersignStrategy,m.CountersignPer,m.BackType }).SingleOrDefault();

            #region 新增下级任务

            if (currentStep != null)
            {
                if (currentTask.Status == 1 || currentTask.Status == 2)
                {
                    FlowTaskRepository.UnitOfWork.TransactionEnabled = true;  //事务处理
                    bool createNextTask = true;

                    switch (currentStep.CountersignStrategy)
                    {
                        case 0:                      //所有步骤同意   
                            int count = GetSiblingTask(currentTask.FlowItemId, currentTask.StepId).Where(c => c.Status < 10).Count();
                            if (count > 1)
                            {
                                createNextTask = false;
                            }
                            break;
                        case 1:                      //一人同意即可
                            CompletedOtherSiblingTask(currentTask, 30, "", "他人已处理此任务！");
                            break;
                        case 2:                      //比例同意即可
                            decimal percentage = currentStep.CountersignPer <= 0 ? 100 : currentStep.CountersignPer;
                            IQueryable<WorkFlowTask> TaskQueryable = GetSiblingTask(currentTask.FlowItemId, currentTask.StepId).Where(c => c.PrevId == currentTask.PrevId);
                            if (Math.Round((((decimal)(TaskQueryable.Where(p => p.Status == 10).Count() + 1) / (decimal)TaskQueryable.Where(p => p.Status <= 10).Count()) * 100), 2, MidpointRounding.AwayFromZero) < percentage)
                            {
                                createNextTask = false;
                            }
                            else
                            {
                                CompletedOtherSiblingTask(currentTask, 30, "", "他人已处理此任务！");
                            }
                            break;
                    }
                    if (createNextTask)
                    {
                        CreatedNextTask(task, currentTask.StepId);
                    }
                    CompletedTask(currentTask, 10, task.Comment);
                    FlowTaskRepository.UnitOfWork.SaveChanges();

                    //是否超期处理
                    
                }
                else
                {
                    return new OperationResult(OperationResultType.ValidError, "当前步骤已经由他人处理！");
                }

            }
            else
            {
                re = new OperationResult(OperationResultType.ValidError, "找不到当前步骤！");
            }

            #endregion

            return re;
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

        /// <summary>
        /// 创建第一个任务
        /// </summary>
        /// <param name="task">当前任务Dto</param>
        /// <returns>业务操作结果</returns>
        protected OperationResult CreateFirstTask(FlowExecuteDto task)
        {
            OperationResult re = CheckFlow(task.FlowId, task.EntityId);
            if (re.ResultType == OperationResultType.Success)
            {
                var firstStep = FlowStepRepository.Entities.First(c =>c.FlowDesignId==task.FlowId && c.StepType == 0);    //起始步骤
                var flowItemId = CombHelper.NewComb();
                task.IsSeal = false;
                var id = CombHelper.NewComb();
                WorkFlowTask taskModel = new WorkFlowTask()
                {
                    Id = id,
                    PrevId = id,
                    FlowItemId = flowItemId,
                    PrevStepId = -1,
                    StepId = firstStep.StepId,
                    StepName = firstStep.StepName,
                    SenderId = task.SenderId,
                    SenderName=task.SenderName,
                    ReceiverId = task.SenderId,
                    ReceiverName = task.SenderName,
                    Comment = task.Comment,
                    CountersignType=0,
                    CountersignStrategy=0,
                    CountersignPer=100,
                    BackType=0,
                    IsArchives=false,
                    Status = 1
                };
                taskModel.FlowItem = new WorkFlowItem()
                {
                    Id = flowItemId,
                    FlowDesignId = task.FlowId,
                    EntityId = task.EntityId,
                    EntityName = task.Title,
                    CreatorUserId = task.SenderId,
                    CreatorUserName=task.SenderName,
                    //StepDay,DelayDay,HandleDay 用触发器保证数据正确性
                    Status = 0
                };

                FlowTaskRepository.Insert(taskModel);
                re = new OperationResult(OperationResultType.Success, "流程启动成功！");
                //re.Data = taskModel;

            }
            return re;
        }

        /// <summary>
        /// 检查流程
        /// </summary>
        /// <param name="flowId">流程Id</param>
        /// <param name="entityId">实体Id</param>
        /// <returns>业务操作结果</returns>
        protected OperationResult CheckFlow(Guid flowId, Guid entityId)
        {
            OperationResult result = new OperationResult(OperationResultType.Success);
            var flow= FlowDesignRepository.Entities.Where(c => c.Id == flowId).Select(m => new { StartStepCont = m.Steps.Count(c => c.StepType == 0), EndStepCont = m.Steps.Count(c => c.StepType == 2) }).SingleOrDefault();
            if (flow!=null)
            {
                if (!(flow.StartStepCont == 1 && flow.EndStepCont == 1))
                {
                    result = new OperationResult(OperationResultType.ValidError, "流程必须有一个起始和结束步骤！");
                }
                if (FlowItemRepository.Entities.Any(c => c.EntityId == entityId && c.Status == 0 && c.FlowDesignId == flowId))
                {
                    return new OperationResult(OperationResultType.ValidError, "当前实体已经启动了流程，且并未结束！");
                }
            }
            else
            {
                result = new OperationResult(OperationResultType.ValidError, "流程不存在！");
            }
            return result;
        }

        /// <summary>
        /// 处理同级他人未完成的任务状态
        /// </summary>
        /// <param name="currentTask">任务实体</param>
        /// <param name="status">标记状态</param>
        /// <param name="Comment">提交意见</param>
        /// <param name="Note">任务说明</param>
        protected void CompletedOtherSiblingTask(WorkFlowTask currentTask, short status, string Comment = "", string Note = "")
        {
            List<WorkFlowTask> OtherSiblingTaskList = FlowTaskRepository.Entities.Where(c => c.FlowItemId == currentTask.FlowItemId && c.StepId == currentTask.StepId && c.Id != currentTask.Id && (c.Status == 1 || c.Status == 2)).ToList();    //找同级步骤他人未完成的任务
            if (OtherSiblingTaskList.Count > 0)
                foreach (var task in OtherSiblingTaskList)
                {
                    task.CompletedTime = DateTime.Now;
                    task.Comment = Comment;
                    task.TaskNote = Note;
                    task.Status = status;
                    FlowTaskRepository.Update(task);
                }
        }

        /// <summary>
        /// 根据指定流程 选择的流转步骤创建任务
        /// </summary>
        /// <param name="task">当前任务Dto</param>
        /// <param name="stepId">当前步骤Id</param>
        protected void CreatedNextTask(FlowExecuteDto task, short stepId)
        {
            foreach (var step in task.Steps)
            {
                //流转的下个步骤
                var nextStep = FlowStepRepository.Entities.Single(p => p.StepId == step.Key);
                foreach (var user in step.Value)
                {
                    var uid=user.Key;
                    var uname=user.Value;
                    GetReceiver(task.FlowId,ref uid,ref uname);
                    WorkFlowTask taskModel = new WorkFlowTask()
                    {
                        Id =CombHelper.NewComb(),
                        PrevId = task.TaskId,
                        FlowItemId = task.EntityId,
                        PrevStepId = stepId,
                        StepId = nextStep.StepId,
                        StepName = nextStep.StepName,
                        SenderId = task.SenderId,
                        SenderName=task.SenderName,
                        ReceiverId = uid,
                        ReceiverName=uname,
                        CountersignType=nextStep.CountersignType,
                        CountersignStrategy = nextStep.CountersignStrategy,
                        CountersignPer = nextStep.CountersignPer,
                        BackType = nextStep.BackType,
                        SpecifiedBackStep = nextStep.SpecifiedBackStep,
                        IsArchives = nextStep.IsArchives,
                        StepDay = nextStep.SpecifiedDay,
                        Status = 1
                    };
                    FlowTaskRepository.Insert(taskModel);
                }

            }
        }

        /// <summary>
        /// 获取 指定流程 指定审批人的流转用户
        /// </summary>
        /// <param name="flowId">流程Id</param>
        /// <param name="userId">审批人Id</param>
        /// <param name="userName">审批人名称</param>
        protected void GetReceiver(Guid flowId,ref string userId,ref string userName)
        {
            var uid = userId;
            var delegation = FlowDelegationRepository.Entities.Where(c => c.FlowDesignId == flowId && c.Status == 1 && c.CreatorUserId == uid
                && c.StartTime <= DateTime.Now && c.EndTime >= DateTime.Now).Select(m => new { m.TrusteeId,m.TrusteeName}).FirstOrDefault();
            if (delegation != null)
            {
                userId = delegation.TrusteeId;
                userName = delegation.TrusteeName;
            }
        }

        /// <summary>
        /// 设置当前任务状态
        /// </summary>
        /// <param name="currentTask">任务实体</param>
        /// <param name="status">标记状态</param>
        /// <param name="Comment">提交意见</param>
        /// <param name="Note">任务说明</param>
        protected void CompletedTask(WorkFlowTask currentTask, short status, string Comment = "", string Note = "")
        {
            if (currentTask != null)
            {
                currentTask.CompletedTime = DateTime.Now;
                currentTask.Comment = Comment;
                currentTask.TaskNote = Note;
                currentTask.Status = status;
                FlowTaskRepository.Update(currentTask);
            }
        }

        #endregion
    }
}
