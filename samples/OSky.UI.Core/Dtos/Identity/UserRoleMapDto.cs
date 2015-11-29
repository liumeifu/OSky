using OSky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSky.UI.Dtos.Identity
{
    public class UserRoleMapDto : IAddDto, IEditDto<int>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 获取或设置 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 获取或设置 用户Id
        /// </summary>
        public int UserId { get; set; }
    }
}
