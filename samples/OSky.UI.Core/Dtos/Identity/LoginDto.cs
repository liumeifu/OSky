using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;

namespace OSky.UI.Dtos.Identity
{
    /// <summary>
    /// 登录信息DTO
    /// </summary>
    public class LoginDto 
    {
        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string CheckCode { get; set; }
    }
}
