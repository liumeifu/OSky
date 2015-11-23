using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSky.UI.Contracts;
using System.ComponentModel;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.UI;
using OSky.Utility.Data;
using OSky.Web.Mvc.Extensions;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    public class MatterController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [HttpPost]
        [Description("工作流-事项管理-视图数据")]
        public ActionResult GridData()
        {
            GridRequest request = new GridRequest(Request);
            request.AddDefaultSortCondition(new SortCondition("CreatedTime", ListSortDirection.Descending));
            var page = GetPageResult(FlowContract.FlowItems,
                m => new
                {
                    m.Id,
                    m.EntityName,
                    m.CreatorUserName,
                    m.CreatedTime,
                    m.DelayDay,
                    m.StepDay,
                    m.HandleDay
                },
                request);
            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Description("工作流-事项详情-视图数据")]
        public ActionResult Detail(Guid Id)
        {
            GridRequest request = new GridRequest(Request);
            request.AddDefaultSortCondition(new SortCondition("CreatedTime", ListSortDirection.Descending));
            var page = GetPageResult(FlowContract.FlowItems,
                m => new
                {
                    m.Id,
                    m.EntityName,
                    m.CreatorUserName,
                    m.CreatedTime,
                    m.DelayDay,
                    m.StepDay,
                    m.HandleDay
                },
                request);
            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法
       
        #endregion

        #endregion

        #region 视图功能
        #region Overrides of AdminBaseController

        [Description("管理-事项-列表")]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #endregion
    }
}