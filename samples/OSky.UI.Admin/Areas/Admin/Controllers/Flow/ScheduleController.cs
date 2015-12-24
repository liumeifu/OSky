using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.UI;
using OSky.UI.Contracts;
using OSky.Web.Mvc.Extensions;
using OSky.UI.Dtos.Flow;
using OSky.Utility.Extensions;
using OSky.UI.Models.Flow;
using OSky.Core.Data.Extensions;
using OSky.Utility.Data;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("工作流-待办事项")]
    public class ScheduleController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("工作流-待办事项-列表数据")]
        public ActionResult GridData()
        {
            GridRequest request = new GridRequest(Request);
            var predicate = ExpressionExtensions.True<WorkFlowTask>();
            predicate = predicate.And(c => (c.Status == 1 || c.Status == 2) && c.ReceiverId == Operator.UserId);
            var page = FlowContract.FlowTasks.ToPage(predicate, request.PageCondition, m => new
                {
                    m.Id,
                    m.FlowItemId,
                    m.FlowItem.FlowDesignId,
                    m.FlowItem.EntityId,
                    m.FlowItem.EntityName,
                    m.StepName,
                    m.SenderName,
                    m.CreatedTime,
                    m.Status,
                    m.StepDay,
                    m.DelayDay,
                    m.DelayReason
                });
            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region 功能方法

        [HttpPost]
        [AjaxOnly]
        [Description("工作流-任务-查看")]
        public ActionResult Scan(Guid TaskId)
        {
            return Json(FlowContract.OpenTask(TaskId).ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("工作流-任务-受理")]
        public ActionResult StartFlow(FlowExecuteDto dto)
        {
            dto.TaskId = Guid.Empty;
            dto.ExecuteType = ExecuteType.Submit;
            dto.SenderId = Operator.UserId;
            dto.SenderName = Operator.NickName;
            var re = FlowContract.Execute(dto);
            return Json(re.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("工作流-任务-审核")]
        public ActionResult ExecuteAudit(FlowProjectDto dto)
        {
            var Edto = new FlowExecuteDto()
            {
                FlowId = dto.FlowId,
                TaskId = dto.TaskId,
                ItemId = dto.ItemId,
                ExecuteType = ExecuteType.Submit,
                SenderId = Operator.UserId,
                SenderName = Operator.NickName
            };
            return Json(Execute(Edto), JsonRequestBehavior.AllowGet);

        }

        [Description("工作流-任务-发送")]
        public ActionResult Execute(FlowExecuteDto dto)
        {
            var steps = new Dictionary<int, Dictionary<string,string>>();
            if (!string.IsNullOrEmpty(Request.Params["stepCheck"]))
            {
                var stepsIds = Request.Params["stepCheck"].Split(',');
                foreach (var stepId in stepsIds)
                {
                    if (!string.IsNullOrEmpty(Request.Params["stepCheck_receive_Id_" + stepId]))
                    {
                        var userIds = Request.Params["stepCheck_receive_Id_" + stepId].Split(',');
                        var userNames = Request.Params["stepCheck_receive_Name_" + stepId].Split(',');
                        var userList = new Dictionary<string,string>();
                        for (int i = 0; i < userIds.Length;i++ )
                        {
                            userList.Add(userIds[i],userNames[i]);
                        }
                        steps.Add(int.Parse(stepId), userList);
                    }
                }
            }
            dto.ExecuteType = ExecuteType.Submit;
            dto.SenderId = Operator.UserId;
            dto.SenderName = Operator.NickName;
            dto.Steps = steps;
            if (steps == null)
                return Json(new OperationResult(OperationResultType.Error, "请指定发送人！").ToAjaxResult());
            return Json(FlowContract.Execute(dto).ToAjaxResult(),JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        [HttpPost]
        [Description("工作流-任务-完成")]
        public ActionResult Completed(Guid TaskId)
        {
            FlowExecuteDto execut = new FlowExecuteDto()
            {
                TaskId = TaskId,
                ExecuteType = ExecuteType.Completed
            };
            return Json(FlowContract.Execute(execut).ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [Description("工作流-任务-退回")]
        public ActionResult Backed(FlowExecuteDto dto)
        {
            var steps = new Dictionary<int, Dictionary<string,string>>();
            if (!string.IsNullOrEmpty(Request.Params["stepCheck"]))
            {
                var stepsIds = Request.Params["stepCheck"].Split(',');
                foreach (var stepId in stepsIds)
                {
                    steps.Add(int.Parse(stepId), null);
                }
            }
            dto.ExecuteType = ExecuteType.Back;
            dto.SenderId = Operator.UserId;
            dto.SenderName = Operator.NickName;
            dto.Steps = steps;
            if (steps == null)
                return Json(new OperationResult(OperationResultType.Error, "请指定退回人！"));
            return Json(FlowContract.Execute(dto).ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        [Description("工作流-任务-撤销")]
        public ActionResult CallBack(Guid TaskId)
        {
            FlowExecuteDto dto = new FlowExecuteDto()
            {
                TaskId = TaskId,
                ExecuteType = ExecuteType.CallBack
            };
            return Json(FlowContract.Execute(dto).ToAjaxResult());
        }

        #endregion

        #endregion

        #region 视图功能

        [Description("工作流-待办事项-列表")]
        public ActionResult Index()
        {
            return View();
        }

        [Description("工作流-待办事项-办理信息")]
        public ActionResult FlowHandle(FlowProjectDto dto)
        {
            var form = FlowContract.FlowRelateForms.Where(c => c.FlowDesignId == dto.FlowId).Select(m => new { m.FlowForm.FilePath, m.FlowForm.ActionPath }).SingleOrDefault();
            dto.FileUrl = form.FilePath;
            dto.ActionUrl = form.ActionPath;
            return View(FlowContract.GetFlowOperateStatus(dto, Operator.UserId));
        }

        [Description("工作流-任务-发送下一步")]
        public ActionResult ExecuteForm(FlowExecuteFormDto dto)
        {
            dto = FlowContract.GetFlowNextStep(dto);
            return View(dto);
        }

        [Description("工作流-任务-退回")]
        public ActionResult ExecuteBack(Guid TaskId, Guid FlowId)
        {
            return View(FlowContract.GetBackSteps(TaskId,FlowId));
        }

        [Description("工作流-任务-审批过程")]
        public ActionResult ApprovalList(Guid ItemId)
        {
            var list = FlowContract.FlowTasks.Where(c => c.FlowItemId == ItemId).Select(m => new FlowApprovalDto{ 
                StepName=m.StepName,
                SenderName=m.SenderName,
                CreatedTime=m.CreatedTime,
                ReceiverName=m.ReceiverName,
                CompletedTime=m.CompletedTime,
                Status=m.Status,
                Comment=m.Comment,
                TaskNote=m.TaskNote
            }).ToList();
            return View(list);
        }
        #endregion
    }
}