using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Models.Identity;

namespace OSky.UI.Services
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 用户角色映射信息查询数据集
        /// </summary>
        public IQueryable<UserRoleMap> UserRoleMaps
        {
            get { return UserRoleMapRepository.Entities; }
        }

        #endregion
    }
}
