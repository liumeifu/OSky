using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using OSky.Utility.Drawing;
using OSky.Utility.Data;
using OSky.UI.Dtos.Identity;
using OSky.Utility;
using OSky.Utility.Secutiry;
using OSky.UI.Contracts;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using OSky.UI.Models.Identity;
using System.Net;
using Microsoft.Owin.Security;
using System.Text;
using OSky.Core.Exceptions;

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    [Description("管理-登录")]
    public class LoginController : Controller
    {
        /// <summary>
        /// 获取或设置 身份认证业务对象
        /// </summary>
        public IIdentityContract IdentityContract { get; set; }
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }

        #region Ajax功能

        #region 获取数据

        [Description("管理-登录-验证码")]
        public ActionResult ValidateCode()
        {
            string strCoder = "";
            ValidateCoder vCoder = new ValidateCoder() { Height = 32, RandomColor = true, RandomPosition = false, RandomItalic = false };
            MemoryStream ms = new MemoryStream();
            vCoder.CreateImage(4, out strCoder, ValidateCodeType.NumberAndLetter).Save(ms, ImageFormat.Jpeg);
            Session["ValidateCode"] = strCoder;
            return File(ms.GetBuffer(), @"image/jpeg");
        }
       
        #endregion

        #region 功能方法

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Description("登录-登录-验证")]
        public ActionResult Login(LoginDto dto)
        {
            dto.CheckNotNull("dto");
            OperationResult result = new OperationResult(OperationResultType.ValidError);
            if (ModelState.IsValid)
            {
                try
                {
                    if (Session["ValidateCode"] == null|| !dto.CheckCode.ToLower().Equals(Session["ValidateCode"].ToString().ToLower()))
                    {
                        ModelState.AddModelError("CheckCode", "验证码不正确!");
                    }
                    else
                    {
                        //CommunicationCryptor cryptor = new CommunicationCryptor("", "", "SHA1");
                        //dto.LoginPwd = cryptor.EncryptData(dto.LoginPwd);
                        result = IdentityContract.CheckLogin(dto);
                        if (result.ResultType == OperationResultType.Success)
                        {
                            User user = result.Data as User;
                           
                            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false },
                                new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie).SetClaimsIdentity(user.Id.ToString(), user.UserName, null ));
                            return RedirectToAction("Index", "Home", new { });
                            
                        }
                        else
                        {
                            ModelState.AddModelError("LoginName", result.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Exception", ex.Message);
                }
            }
            ViewBag.ErrorsMessage = GetModelErrors(ModelState);
            return View(dto);
        }

        #endregion

        #endregion

        #region 视图功能
        //
        // GET: /Admin/Login/
        [Description("管理-登录-访问")]
        public ActionResult Index(LoginDto dto)
        {
            if(dto.LoginName==null)
                return View(dto);
            return Login(dto);
        }

        #endregion

        public string GetModelErrors(ModelStateDictionary modelState)
        {
            var errorList = modelState.Values.Where(c => c.Errors.Count > 0).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in errorList)
            {
                sb.Append("【" + item.Errors[0].ErrorMessage + "】");
            }
            return sb.ToString();
        }


	}
}