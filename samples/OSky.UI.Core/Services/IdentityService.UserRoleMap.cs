using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.UI.Models.Identity;
using OSky.Utility.Data;
using OSky.UI.Dtos.Identity;
using OSky.Utility;
using OSky.Utility.Collections;

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
        /// <summary>
        /// 根据指定角色添加用户角色映射信息
        /// </summary>
        /// <param name="dtos">要添加的用户角色映射信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public async Task<OperationResult> AddUserRoleMapsByRole(params UserRoleMapDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            var rid = dtos[0].RoleId;
            var list = UserRoleMaps.Where(c => c.RoleId == rid).Select(m => new UserRoleMapDto
            {
                Id=m.Id,
                UserId=m.UserId,
                RoleId=m.RoleId
            }).ToList();
            //删除移除的用户
            var removeItems = list.Except(dtos, EqualityHelper<UserRoleMapDto>.CreateComparer(m => m.RoleId + m.UserId)).Select(m=>m.Id).ToArray();
            OperationResult result = await DeleteUserRoleMaps(removeItems);
            //添加新增的用户
            var items = dtos.Except(list, EqualityHelper<UserRoleMapDto>.CreateComparer(m => m.RoleId + m.UserId)).ToArray();
            if (items.Count() > 0)
                result = await Task.FromResult(UserRoleMapRepository.Insert(items));
            return result;
        }

        /// <summary>
        /// 根据指定用户添加用户角色映射信息
        /// </summary>
        /// <param name="dtos">要添加的用户角色映射信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public async Task<OperationResult> AddUserRoleMapsByUser(params UserRoleMapDto[] dtos)
        {
            dtos.CheckNotNull("dtos");
            var uid = dtos[0].UserId;
            var list = UserRoleMaps.Where(c => c.UserId == uid).Select(m => new UserRoleMapDto
            {
                Id = m.Id,
                UserId = m.UserId,
                RoleId = m.RoleId
            }).ToList();
            //删除移除的用户
            var removeItems = list.Except(dtos, EqualityHelper<UserRoleMapDto>.CreateComparer(m => m.RoleId + m.UserId)).Select(m => m.Id).ToArray();
            OperationResult result = await DeleteUserRoleMaps(removeItems);
            //添加新增的用户
            var items = dtos.Except(list, EqualityHelper<UserRoleMapDto>.CreateComparer(m => m.RoleId + m.UserId)).ToArray();
            if (items.Count() > 0)
                result = await Task.FromResult(UserRoleMapRepository.Insert(items));
            return result;
        }
        /// <summary>
        /// 删除用户角色映射信息
        /// </summary>
        /// <param name="ids">要删除的用户角色映射编号</param>
        /// <returns>业务操作结果</returns>
        public async Task<OperationResult> DeleteUserRoleMaps(params int[] ids)
        {
            OperationResult result = UserRoleMapRepository.Delete(ids,null);
            return await Task.FromResult(result);
        }

        #endregion
    }
}
