using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Context;
using Microsoft.Owin;
using System.Security.Claims;
using OSky.Core.Exceptions;
using System.Web;

namespace OSky.Web.Mvc.Extensions
{
    /// <summary>
    /// <see cref="Operator"/>扩展辅助操作类
    /// </summary>
    public static class OperatorHelper
    {
        public static Operator GetOperator(HttpContextBase _context)
        {
            var claimsIdentity = _context.GetOwinContext().Authentication.User.Identity as ClaimsIdentity;
            return new Operator()
            {
                UserId = claimsIdentity.GetClaimValue(ClaimTypes.NameIdentifier),
                UserName = claimsIdentity.GetClaimValue(ClaimTypes.Name),
                NickName = claimsIdentity.GetClaimValue(ClaimTypes.Surname),
                Ip = _context.Request.GetIpAddress()
            };
        }
    }
}
