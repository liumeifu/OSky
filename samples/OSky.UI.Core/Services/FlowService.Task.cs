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
            var currentTask = FlowTaskRepository.Entities.Where(c => c.Id == dto.TaskId).Select(m => new { m.Id,m.PrevId,m.StepId,m.Status,m.ReceiverId,m.PrevStepId}).SingleOrDefault();
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
                    if (currentTask.PrevStepId == -1)
                        status.HasSave = true;
                    //判断任务是否可以撤销
                    OperationResult result = IsCallBack(dto.TaskId);
                    if (result.ResultType == OperationResultType.Success && currentTask.PrevId != Guid.Empty)
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
        /// 获取 根据指定任务的下一步骤信息dto
        /// </summary>
        /// <param name="stepDto">流转步骤信息dto</param>
        /// <returns>下一步骤信息dto</returns>
        public FlowExecuteFormDto GetFlowNextStep(FlowExecuteFormDto stepDto)
        {
            var current = FlowTaskRepository.Entities.Where(c => c.Id == stepDto.TaskId).
                Select(c => new { FlowId = c.FlowItem.FlowDesignId, StepId = c.StepId, PrevID = c.PrevId, c.IsComment, c.IsSeal, c.IsArchive }).Single();

            var currentLines = FlowLineRepository.Entities.Where(c => c.FlowDesignId == current.FlowId && c.FromStepId == current.StepId).Select(c => new { c.ToStepId, c.ToStepName, c.HandlerIds, c.HandlerNames }).ToList();
            foreach (var item in currentLines)
            {
                StepToUser stepUser = new StepToUser();
                stepUser.HandlerIds = item.HandlerIds;
                stepUser.HandlerNames = item.HandlerNames;
                stepUser.StepId = item.ToStepId;
                stepUser.StepName = item.ToStepName;
                stepDto.StepToUsers.Add(stepUser);
            }
            stepDto.IsComment = current.IsComment;
            stepDto.IsSeal = current.IsSeal;
            stepDto.IsArchive = current.IsArchive;

            return stepDto;
        }

        /// <summary>
        /// 执行 流转任务
        /// </summary>
        /// <param name="taskDto">当前任务Dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Execute(FlowExecuteDto taskDto)
        {
            OperationResult result = new OperationResult(OperationResultType.NoChanged);
            switch (taskDto.ExecuteType)
            {
                case ExecuteType.Submit:
                    result = ExecuteSubmit(taskDto);
                    break;
                case ExecuteType.Back:
                    result = ExecuteBack(taskDto);
                    break;
                case ExecuteType.CallBack:
                    result = ExecuteCallBack(taskDto);
                    break;
                case ExecuteType.Completed:
                    result = ExecuteCompleted(taskDto);
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取 可退回的步骤
        /// </summary>
        /// <param name="TaskId">流程任务Id</param>
        /// <param name="FlowId">流程Id</param>
        /// <returns>步骤<StepId,StepName>的键值对数据集</returns>
        public Dictionary<int, string> GetBackSteps(Guid TaskId, Guid FlowId)
        {
            Dictionary<int, string> steps = new Dictionary<int, string>();
            //当前任务
            var task = FlowTasks.Where(c => c.Id == TaskId).Select(m => new { m.StepId,m.PrevId}).SingleOrDefault();
            //当前步骤
            var step = FlowSteps.Where(c => c.FlowDesignId == FlowId && c.StepId == task.StepId).Select(m => new { m.StepType, m.BackType,m.SpecifiedBackStep }).FirstOrDefault();
            if (step.StepType != 0)
            {
                switch (step.BackType)
                {
                    //退回到上一步
                    case 1:
                        var prevTask = FlowTasks.Where(c => c.Id == task.PrevId).Select(m => new { m.StepId, m.StepName }).SingleOrDefault();
                        steps.Add(prevTask.StepId, prevTask.StepName);
                        break;
                    //退回到第一步
                    case 2:
                        var fisrtStep = FlowSteps.Where(c => c.StepType == 0 && c.FlowDesignId==FlowId).Select(m => new { m.StepId, m.StepName }).SingleOrDefault();
                        steps.Add(fisrtStep.StepId, fisrtStep.StepName);
                        break;
                    //退回到指定步
                    case 3:
                        if (!string.IsNullOrEmpty(step.SpecifiedBackStep))
                        {
                            var singStep = FlowSteps.Where(c => c.FlowDesignId == FlowId && c.StepName == step.SpecifiedBackStep).Select(m => new { m.StepId, m.StepName }).SingleOrDefault();
                            steps.Add(singStep.StepId, singStep.StepName);
                        }
                        break;
                    default:
                        break;

                       
                }
            }
            return steps;
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
                Select(m => new { m.StepType, m.CountersignStrategy, m.CountersignPer, m.BackType }).SingleOrDefault();

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

        /// <summary>
        /// 退回任务
        /// </summary>
        /// <param name="task">当前任务Dto</param>
        /// <returns>业务操作结果</returns>
        protected OperationResult ExecuteBack(FlowExecuteDto task)
        {
            OperationResult re = new OperationResult(OperationResultType.NoChanged, "退回未处理！");
            var currentTask = FlowTaskRepository.Entities.Single(c => c.Id == task.TaskId);

            if (currentTask != null)
            {
                if (currentTask.Status != 1 && currentTask.Status != 2)
                {
                    return new OperationResult(OperationResultType.ValidError, "任务已经处理，不能进行退回！");
                }

                var currentStep = FlowStepRepository.Entities.Where(c => c.FlowDesignId == task.FlowId && c.StepId == currentTask.StepId).Select(m => new { m.StepType, m.BackType, m.SpecifiedBackStep }).SingleOrDefault();

                if (currentStep.StepType == 0)
                {
                    return new OperationResult(OperationResultType.ValidError, "流程的第一个步骤不能退回！");
                }
                if (currentStep.BackType == 0)
                {
                    return new OperationResult(OperationResultType.ValidError, "当前步骤为不可退回步骤！");
                }

                #region 退回处理
                List<WorkFlowTask> backTasks = new List<WorkFlowTask>();

                if (currentStep.StepType == 1)                                         //退回到上一步
                {
                    backTasks.AddRange(GetSiblingTask(currentTask.FlowItemId, currentTask.PrevStepId).ToList());
                }
                else if (currentStep.BackType == 2)                                        //退回到第一步
                {
                    var firstTack = FlowTaskRepository.Entities.Where(c => c.StepId == 2 && c.FlowItemId == currentTask.FlowItemId).OrderByDescending(c => c.CreatedTime).Single();
                    firstTack.PrevId = task.TaskId;  //上一个任务Id
                    backTasks.Add(firstTack);
                }
                else                                                                     //退回到指定步
                {
                    var backStep = FlowStepRepository.Entities.Where(c => c.FlowDesignId == task.FlowId && c.StepName == currentStep.SpecifiedBackStep).Select(c => new { c.StepId }).Single();
                    if (backStep == null)
                    {
                        return new OperationResult(OperationResultType.ValidError, "当前流程步骤配置有误,不能退回！");
                    }
                    backTasks.AddRange(GetSiblingTask(currentTask.FlowItemId, backStep.StepId).ToList());
                }

                FlowTaskRepository.UnitOfWork.TransactionEnabled = true;  //事务处理
                foreach (var item in backTasks)
                {
                    WorkFlowTask newTask = new WorkFlowTask();
                    newTask.Id = CombHelper.NewComb();
                    newTask.PrevId = item.PrevId;
                    newTask.FlowItemId = item.FlowItemId;
                    newTask.PrevStepId = item.PrevStepId;
                    newTask.StepId = item.StepId;
                    newTask.StepName = item.StepName;
                    newTask.SenderId = task.SenderId;
                    newTask.SenderName = task.SenderName;
                    newTask.ReceiverId = item.ReceiverId;
                    newTask.ReceiverName = item.ReceiverName;
                    newTask.OpenedTime = null;
                    newTask.CompletedTime = null;
                    newTask.Comment = task.Comment;
                    newTask.IsComment = item.IsComment;
                    newTask.IsSeal = item.IsSeal;
                    newTask.IsArchive = item.IsArchive;
                    newTask.TaskNote = "退回的任务";
                    newTask.StepDay = item.StepDay;
                    newTask.DelayDay = 0;
                    newTask.Status = 1;

                    FlowTaskRepository.Insert(newTask);

                }

                CompletedTask(currentTask, 20, task.Comment);
                CompletedOtherSiblingTask(currentTask, 40, "", "他人已退回");

                FlowTaskRepository.UnitOfWork.SaveChanges();
                re = new OperationResult(OperationResultType.Success, "退回成功！");

                #endregion
            }
            else
            {
                re = new OperationResult(OperationResultType.ValidError, "您要退回的任务不存在！");
            }
            return re;
        }

        /// <summary>
        /// 撤销提交
        /// </summary>
        /// <param name="task">当前任务Dto</param>
        /// <returns>业务操作结果</returns>
        protected OperationResult ExecuteCallBack(FlowExecuteDto task)
        {
            OperationResult result = IsCallBack(task.TaskId);
            if (result.ResultType != OperationResultType.Success)
                return new OperationResult(OperationResultType.ValidError, "任务在下级已经有处理，不能再撤销！");
            FlowTaskRepository.UnitOfWork.TransactionEnabled = true;  //事务处理
            var nextTask = (List<WorkFlowTask>)result.Data;
            foreach (var item in nextTask)
            {
                FlowTaskRepository.Delete(item);
            }
            //标记本任务为待处理
            var currentTask = FlowTaskRepository.Entities.Where(c => c.Id == task.TaskId).Single();
            CompletedTask(currentTask, 1, "", "撤销提交的任务");
            var currentSiblingTask = GetSiblingTask(currentTask.FlowItemId, currentTask.StepId).Where(c => c.Status == 30).ToList();
            foreach (var item in currentSiblingTask)
            {
                CompletedTask(item, 1, task.Comment, "他人已撤销提交的任务");
            }
            FlowTaskRepository.UnitOfWork.SaveChanges();
            result = new OperationResult(OperationResultType.Success, "撤销成功！");
            
            return result;
        }

        /// <summary>
        /// 办结任务
        /// </summary>
        /// <param name="task">当前任务Dto</param>
        /// <returns>业务操作结果</returns>
        protected OperationResult ExecuteCompleted(FlowExecuteDto task)
        {
            OperationResult re = new OperationResult(OperationResultType.NoChanged, "办结未做处理！");
            var currentTask = FlowTaskRepository.Entities.SingleOrDefault(c => c.Id == task.TaskId);
            if (currentTask != null)
            {
                currentTask.FlowItem.Status = 1;
                currentTask.FlowItem.CompletedTime = DateTime.Now;
                currentTask.Comment = task.Comment;
                currentTask.TaskNote = task.Note;
                currentTask.Status = 10;
                currentTask.CompletedTime = DateTime.Now;
                FlowTaskRepository.UnitOfWork.TransactionEnabled = true;  //事务处理
                
                if (currentTask.IsArchive)
                    FlowArchiveRepository.Insert(new WorkFlowArchive()
                    {
                        Id = CombHelper.NewComb(),
                        FlowItemId = currentTask.FlowItemId,
                        CreatorUserName = task.SenderName
                    });
                FlowTaskRepository.Update(currentTask);
                FlowTaskRepository.UnitOfWork.SaveChanges();
                
                re = new OperationResult(OperationResultType.Success, "成功办结!");
            }
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
                var firstStep = FlowStepRepository.Entities.Where(c => c.FlowDesignId == task.FlowId && c.StepType == 0).Select(m => new { m.StepId,m.StepName}).SingleOrDefault();    //起始步骤
                var flowItemId = CombHelper.NewComb();
                var id = CombHelper.NewComb();
                WorkFlowTask taskModel = new WorkFlowTask()
                {
                    Id = id,
                    FlowItemId = flowItemId,
                    PrevStepId = -1,
                    StepId = firstStep.StepId,
                    StepName = firstStep.StepName,
                    SenderId = task.SenderId,
                    SenderName=task.SenderName,
                    ReceiverId = task.SenderId,
                    ReceiverName = task.SenderName,
                    CreatedTime=DateTime.Now,
                    Comment = task.Comment,
                    IsComment = false,
                    IsSeal = false,
                    IsArchive=false,
                    Status = 1
                };
                var model = new WorkFlowItem()
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
                model.Tasks.Add(taskModel);
                FlowItemRepository.Insert(model);
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
                var nextStep = FlowStepRepository.Entities.Single(p => p.StepId == step.Key && p.FlowDesignId==task.FlowId);
                foreach (var user in step.Value)
                {
                    var uid=user.Key;
                    var uname=user.Value;
                    GetReceiver(task.FlowId,ref uid,ref uname);
                    WorkFlowTask taskModel = new WorkFlowTask()
                    {
                        Id = CombHelper.NewComb(),
                        PrevId = task.TaskId,
                        FlowItemId = task.ItemId,
                        PrevStepId = stepId,
                        StepId = nextStep.StepId,
                        StepName = nextStep.StepName,
                        SenderId = task.SenderId,
                        SenderName = task.SenderName,
                        ReceiverId = uid,
                        ReceiverName = uname,
                        IsComment = nextStep.CountersignType == 0 ? false : true,
                        IsSeal = nextStep.CountersignType == 2 ? true : false,
                        IsArchive = nextStep.IsArchives,
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
