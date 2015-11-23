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

namespace OSky.UI.Admin.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 获取或设置 身份认证业务对象
        /// </summary>
        public IIdentityContract IdentityContract { get; set; }
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }

        #region Ajax功能

        #region 获取数据
        
        [Description("登录-验证码")]
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
                           
                            //构造登录成功用户的Cookie属性值
                            Dictionary<string, string> userCookieDic = new Dictionary<string, string>() { };
                            userCookieDic.Add("userId", user.Id.ToString());
                            userCookieDic.Add("userName", user.UserName);
                            
                            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false },
                                GetClaimsIdentity(user.Id.ToString(), user.UserName, null, userCookieDic));
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
        //
        // GET: /Admin/Login/
        [Description("管理-登录")]
        public ActionResult Index(LoginDto dto)
        {
            if(dto.LoginName==null)
                return View(dto);
            return Login(dto);
        }
        /// <summary>
        /// 基于Claims-based的认证 
        /// </summary>
        /// <param name="id">登录Id</param>
        /// <param name="name">登录名</param>
        /// <param name="roles">角色集合</param>
        /// <param name="attr">键值对集合</param>
        /// <returns></returns>
        public ClaimsIdentity GetClaimsIdentity(string id,string name, string[] roles, Dictionary<string, string> attr)
        {

            var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id));
            identity.AddClaim(new Claim(ClaimTypes.Name, name));
            if (roles!=null)
                foreach (var item in roles)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, item));
                    }
                }
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2015/11/claims/identityprovider", "ASP.NET Identity"));
            foreach (var item in attr)
            {
                identity.AddClaim(new Claim(item.Key, item.Value));
            }
            return identity;
        }

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