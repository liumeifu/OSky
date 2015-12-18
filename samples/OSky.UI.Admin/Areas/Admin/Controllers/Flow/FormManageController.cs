using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel;
using OSky.Web.Mvc.Security;
using OSky.Web.Mvc.UI;
using OSky.Utility.Data;
using OSky.UI.Contracts;
using System.Linq.Expressions;
using OSky.Utility.Filter;
using OSky.UI.Models.Flow;
using OSky.Utility.Extensions;
using OSky.Web.Mvc.Extensions;
using OSky.Utility;
using OSky.UI.Dtos.Flow;
using OSky.UI.Dtos.Infos;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("工作流-表单管理")]
    public class FormManageController : AdminBaseController
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
        [Description("工作流-表单-列表数据")]
        public ActionResult GridData(string formName)
        {
            GridRequest request = new GridRequest(Request);
            var query = (from form in FlowContract.FlowForms
                         join r in FlowContract.FlowRelateForms on form.Id equals r.FlowFormId into fr
                         from r in fr.DefaultIfEmpty()
                         join d in CommonContract.Dictionarys on form.TypeVal equals d.Value into dic
                         from d in dic.DefaultIfEmpty()
                         select new FlowFormDto
                        {
                            Id=form.Id,
                            FormName=form.FormName,
                            TypeVal = form.TypeVal,
                            TypeName=d.Name,
                            CreatorUserName=form.CreatorUserName,
                            CreatTime=form.CreatedTime,
                            FilePath=form.FilePath,
                            ActionPath=form.ActionPath,
                            EnabledFlow=form.EnabledFlow,
                            Status=form.Status,
                            FlowDesignId=r.FlowDesignId
                        })
                        .WhereIf(c=>c.FormName==formName,!formName.IsNullOrEmpty());
            var total = query.Count();
            if (request.PageCondition.SortConditions.Length > 0  )
            {
                foreach (var item in request.PageCondition.SortConditions)
                {
                    query = query.OrderBy(item.SortField, item.ListSortDirection);
                }
            }
            else
                query=query.OrderBy("CreatTime", ListSortDirection.Descending);

            var list = query.Skip((request.PageCondition.PageIndex - 1) * request.PageCondition.PageSize).Take(request.PageCondition.PageSize).ToList();
            var data = new GridData<FlowFormDto>(list, total);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        [Description("工作流-表单-表单类型")]
        public ActionResult DicData()
        {
            var list = CommonContract.Dictionarys.SingleOrDefault(c => c.Value == "BDLX").Children.
                Select(m => new DictionaryDto { Value = m.Value, Name = m.Name });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 功能方法
        [HttpPost]
        [AjaxOnly]
        [Description("工作流-表单-新增")]
        public ActionResult Add(FlowFormDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            foreach (var item in dtos)
            {
                item.CreatorUserName = Operator.UserName;
            }
            OperationResult result = FlowContract.AddFlowForm(dtos);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("工作流-表单-编辑")]
        public ActionResult Edit(FlowFormDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = FlowContract.EditFlowForm(dtos);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("工作流-表单-删除")]
        public ActionResult Delete(Guid[] ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = FlowContract.DeleteFlowForm(ids);
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion

        #region 视图功能

        #region Overrides of AdminBaseController

        [Description("管理-表单-列表")]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #endregion
    }
}