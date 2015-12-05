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
            return new Operator()
            {
                UserId = (_context.GetOwinContext().Authentication.User.Identity as ClaimsIdentity).GetClaimValue(ClaimTypes.NameIdentifier),
                Name = (_context.GetOwinContext().Authentication.User.Identity as ClaimsIdentity).GetClaimValue(ClaimTypes.Name),
                Ip = _context.Request.GetIpAddress()
            };
        }
    }
}
