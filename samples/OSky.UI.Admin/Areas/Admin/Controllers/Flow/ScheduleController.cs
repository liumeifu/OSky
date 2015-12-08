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
            var page = GetPageResult(FlowContract.FlowTasks,
                m => new
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
                },
                request);
            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region 功能方法

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
           var form = FlowContract.FlowRelateForms.Where(c => c.FlowDesignId == dto.FlowId).Select(m => new { m.FlowForm.FilePath,m.FlowForm.ActionPath }).SingleOrDefault();
           dto.FileUrl = form.FilePath;
           dto.ActionUrl = form.ActionPath;
           return View(FlowContract.GetFlowOperateStatus(dto, Guid.Parse(Operator.UserId)));
       }


        #endregion
    }
}