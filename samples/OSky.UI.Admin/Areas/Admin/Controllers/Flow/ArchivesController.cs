using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel;
using OSky.UI.Contracts;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.UI;
using OSky.Web.Mvc.Extensions;
using OSky.Utility.Extensions;
using OSky.UI.Dtos.Flow;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("工作流-档案管理")]
    public class ArchivesController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 工作流业务对象
        /// </summary>
        public IFlowContract FlowContract { get; set; }
        /// <summary>
        /// 获取或设置基础模块业务对象
        /// </summary>
        public ICommonContract CommonContract { get; set; }

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("工作流-档案管理-列表数据")]
        public ActionResult GridData(string entityName)
        {
            GridRequest request = new GridRequest(Request);
            var query = (from a in FlowContract.FlowArchives where a.CreatorUserId==Operator.UserId 
                         join i in FlowContract.FlowItems on a.FlowItemId equals i.Id
                         join r in FlowContract.FlowRelateForms on i.FlowDesignId equals r.FlowDesignId
                         join f in FlowContract.FlowForms on r.FlowFormId equals f.Id 
                         join d in CommonContract.Dictionarys on f.TypeVal equals d.Value
                         select new FlowFormDto
                         {
                             Id = a.Id,
                             FormName = i.EntityName,
                             TypeVal = f.TypeVal,
                             TypeName = d.Name,
                             CreatorUserName = a.CreatorUserName,
                             CreatTime = a.CreatedTime
                         })
                        .WhereIf(c => c.FormName.Contains(entityName), !entityName.IsNullOrEmpty());
            var total = query.Count();
            if (request.PageCondition.SortConditions.Length > 0)
            {
                foreach (var item in request.PageCondition.SortConditions)
                {
                    query = query.OrderBy(item.SortField, item.ListSortDirection);
                }
            }
            else
                query = query.OrderBy("CreatTime", ListSortDirection.Descending);

            var list = query.Skip((request.PageCondition.PageIndex - 1) * request.PageCondition.PageSize).Take(request.PageCondition.PageSize).ToList();
            var data = new GridData<FlowFormDto>(list, total);

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #endregion

        #region 视图功能

        [Description("工作流-档案管理-列表")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion
	}
}