// -----------------------------------------------------------------------
//  <copyright file="IdentityService.Role.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-24 17:10</last-date>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;

using OSky.UI.Dtos.Identity;
using OSky.UI.Models.Identity;
using OSky.Utility.Data;
using OSky.Utility.Extensions;


namespace OSky.UI.Services
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 角色信息查询数据集
        /// </summary>
        public IQueryable<Role> Roles
        {
            get { return RoleRepository.Entities; }
        }

        /// <summary>
        /// 检查角色信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的角色信息编号</param>
        /// <returns>角色信息是否存在</returns>
        public bool CheckRoleExists(Expression<Func<Role, bool>> predicate, int id = 0)
        {
            return RoleRepository.CheckExists(predicate, id);
        }

        /// <summary>
        /// 添加角色信息信息
        /// </summary>
        /// <param name="dtos">要添加的角色信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult AddRoles(params RoleDto[] dtos)
        {
            return RoleRepository.Insert(dtos,
                dto =>
                {
                    if (RoleRepository.CheckExists(m => m.Name == dto.Name))
                    {
                        throw new Exception("名称为“{0}”的角色已存在，不能重复添加。".FormatWith(dto.Name));
                    }
                });
        }

        /// <summary>
        /// 更新角色信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的角色信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult EditRoles(params RoleDto[] dtos)
        {
            return RoleRepository.Update(dtos,
                dto =>
                {
                    if (dto.IsSystem)
                    {
                        throw new Exception("角色“{0}”为系统角色，不能编辑".FormatWith(dto.Name));
                    }
                    
                });
        }

        /// <summary>
        /// 删除角色信息信息
        /// </summary>
        /// <param name="ids">要删除的角色信息编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult DeleteRoles(params int[] ids)
        {
            return RoleRepository.Delete(ids);
        }

        #endregion
    }
}