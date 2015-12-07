using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OSky.Web.Mvc.Security;
using OSky.UI.Contracts;
using System.ComponentModel;
using OSky.Web.Mvc.UI;
using OSky.Web.Mvc.Extensions;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("工作流-流程管理")]
    public class FlowController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("工作流-流程-列表数据")]
        public ActionResult GridData(string formName)
        {
            GridRequest request = new GridRequest(Request);
            var page = GetPageResult(FlowContract.FlowDesigns,
                m => new
                {
                    m.Id,
                    m.FlowType,
                    m.FlowName,
                    m.CreatorUserName,
                    m.CreatedTime,
                    m.Status
                },
                request);
            return Json(page.ToGridData(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法
     
        #endregion

        #endregion

        #region 视图功能

        [Description("工作流-流程-列表")]
        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}