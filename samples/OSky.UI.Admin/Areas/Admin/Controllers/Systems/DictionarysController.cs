using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel;
using OSky.UI.Contracts;
using OSky.UI.Dtos.Infos;
using OSky.Web.Mvc.Security;
using OSky.Utility.Data;
using OSky.Web.Mvc.UI;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("管理-数据字典")]
    public class DictionarysController : AdminBaseController
    {
        /// <summary>
        /// 获取或设置 基础模块
        /// </summary>
         public ICommonContract CommonContract { get; set; }

        #region 视力功能

        [Description("管理-数据字典-访问")]
        public ActionResult Index()
        {
            return View();
        }

        [Description("管理-数据字典-编辑访问")]
        public ActionResult Edit(int id)
        {
            var dto = CommonContract.Dictionarys.Where(c => c.Id == id).Select(m =>
                new DictionaryDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Value = m.Value,
                    SortCode = m.SortCode,
                    ParentId = m.Parent.Id,
                    ParentName=m.Parent.Name
                }).SingleOrDefault();
            if (dto == null)
                dto = new DictionaryDto();
            return View(dto);
        }

        #endregion

        #region Ajax功能

        #region 获取数据

        [AjaxOnly]
        [Description("管理-数据字典-节点数据")]
        public ActionResult NodeData()
        {
            var roots = CommonContract.Dictionarys
                .OrderBy(m => m.SortCode).Select(m => new 
                {
                    id = m.Id,
                    pid = m.ParentId,
                    text = m.Name,
                    Type = 0
                }).ToList();
            return Json(roots, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region 功能方法

        [HttpPost]
        [Description("管理-数据字典-新增")]
        public ActionResult AddDic(DictionaryDto dto)
        {
            OperationResult result = CommonContract.AddDictionarys(dto);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [Description("管理-数据字典-编辑")]
        public ActionResult EditDic(DictionaryDto dto)
        {
            OperationResult result = CommonContract.EditDictionarys(dto);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [AjaxOnly]
        [Description("管理-数据字典-删除")]
        public ActionResult DeleteDic(int id)
        {
            OperationResult result = CommonContract.DeleteDictionarys(id);
            return Json(result.ToAjaxResult());
        }

        #endregion

        #endregion
    }
}