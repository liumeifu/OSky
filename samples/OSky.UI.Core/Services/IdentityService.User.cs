﻿// -----------------------------------------------------------------------
//  <copyright file="IdentityService.User.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-24 17:25</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using OSky.Core.Data.Entity;
using OSky.Core.Identity;
using OSky.UI.Contracts;
using OSky.UI.Dtos.Identity;
using OSky.UI.Identity;
using OSky.UI.Models.Identity;
using OSky.Utility;
using OSky.Utility.Data;
using OSky.Utility.Extensions;


namespace OSky.UI.Services
{
    public partial class IdentityService
    {
        #region Implementation of IIdentityContract

        /// <summary>
        /// 获取 用户信息查询数据集
        /// </summary>
        public IQueryable<User> Users
        {
            get { return UserRepository.Entities; }
        }

        /// <summary>
        /// 获取或设置 用户管理器
        /// </summary>
        public UserManager UserManager { get; set; }

        /// <summary>
        /// 检查用户信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的用户信息编号</param>
        /// <returns>用户信息是否存在</returns>
        public bool CheckUserExists(Expression<Func<User, bool>> predicate, int id = 0)
        {
            return UserRepository.CheckExists(predicate, id);
        }

        /// <summary>
        /// 添加用户信息信息
        /// </summary>
        /// <param name="dtos">要添加的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public async Task<OperationResult> AddUsers(params UserDto[] dtos)
        {
            List<string> names = new List<string>();
            UserRepository.UnitOfWork.TransactionEnabled = true;
            foreach (UserDto dto in dtos)
            {
                IdentityResult result;
                User user = dto.MapTo<User>();
                //密码单独处理
                if (!dto.Password.IsNullOrEmpty())
                {
                    result = await UserManager.PasswordValidator.ValidateAsync(dto.Password);
                    if (!result.Succeeded)
                    {
                        return result.ToOperationResult();
                    }
                    user.PasswordHash = UserManager.PasswordHasher.HashPassword(dto.Password);
                }
                else
                    user.PasswordHash = UserManager.PasswordHasher.HashPassword("123456");
                user.Extend = new UserExtend() { RegistedIp = dto.RegistedIp };
                //判断组织机构是否存在
                if (dto.OrganizationId.HasValue && dto.OrganizationId.Value > 0)
                {
                    Organization organization = OrganizationRepository.GetByKey(dto.OrganizationId.Value);
                    if (organization == null)
                    {
                        throw new Exception("要加入的组织机构不存在。");
                    }
                    user.Organization = organization;
                }
                else
                {
                    throw new Exception("请您先选择所属机构！");
                }

                result = await UserManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return new OperationResult(OperationResultType.Error, result.Errors.ExpandAndToString());
                }
                names.Add(user.UserName);
            }
            return UserRepository.UnitOfWork.SaveChanges() > 0
                ? new OperationResult(OperationResultType.Success, "用户“{0}”创建成功".FormatWith(names.ExpandAndToString()))
                : OperationResult.NoChanged;
        }

        /// <summary>
        /// 更新用户信息信息
        /// </summary>
        /// <param name="dtos">包含更新信息的用户信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public async Task<OperationResult> EditUsers(params UserDto[] dtos)
        {
            List<string> names = new List<string>();
            UserRepository.UnitOfWork.TransactionEnabled = true;
            foreach (UserDto dto in dtos)
            {
                IdentityResult result;
                User user = UserManager.FindById(dto.Id);
                if (user == null)
                {
                    return new OperationResult(OperationResultType.QueryNull);
                }
                user = dto.MapTo(user);
                //密码单独处理
                if (!dto.Password.IsNullOrEmpty())
                {
                    result = await UserManager.PasswordValidator.ValidateAsync(dto.Password);
                    if (!result.Succeeded)
                    {
                        return result.ToOperationResult();
                    }
                    user.PasswordHash = UserManager.PasswordHasher.HashPassword(dto.Password);
                }

                result = await UserManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return new OperationResult(OperationResultType.Error, result.Errors.ExpandAndToString());
                }
                names.Add(dto.UserName);
            }
            return UserRepository.UnitOfWork.SaveChanges() > 0
                ? new OperationResult(OperationResultType.Success, "用户“{0}”更新成功".FormatWith(names.ExpandAndToString()))
                : OperationResult.NoChanged;
        }

        /// <summary>
        /// 删除用户信息信息
        /// </summary>
        /// <param name="ids">要删除的用户信息编号</param>
        /// <returns>业务操作结果</returns>
        public async Task<OperationResult> DeleteUsers(params int[] ids)
        {
            OperationResult result = UserRepository.Delete(ids,null,
                entity =>
                {
                    //先删除所有用户相关信息
                    UserExtendRepository.Delete(entity.Extend);
                    return entity;
                });
            return await Task.FromResult(result);
        }

        /// <summary>
        /// 设置用户的角色
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="roleIds">角色编号集合</param>
        /// <returns>业务操作结果</returns>
        public async Task<OperationResult> SetUserRoles(int id, int[] roleIds)
        {
            User user = await UserRepository.GetByKeyAsync(id);
            if (user == null)
            {
                return new OperationResult(OperationResultType.QueryNull, "指定编号的用户信息不存在");
            }
            int[] existIds = UserRoleMapRepository.Entities.Where(m => m.User.Id == id).Select(m => m.Role.Id).ToArray();
            int[] addIds = roleIds.Except(existIds).ToArray();
            int[] removeIds = existIds.Except(roleIds).ToArray();
            UserRoleMapRepository.UnitOfWork.TransactionEnabled = true;
            foreach (int addId in addIds)
            {
                Role role = await RoleRepository.GetByKeyAsync(addId);
                if (role == null)
                {
                    return new OperationResult(OperationResultType.QueryNull, "指定编号的角色信息不存在");
                }
                UserRoleMap map = new UserRoleMap(){User = user, Role = role};
                await UserRoleMapRepository.InsertAsync(map);
            }
            await UserRoleMapRepository.DeleteAsync(m => m.User.Id == id && removeIds.Contains(m.Role.Id));
            return await UserRoleMapRepository.UnitOfWork.SaveChangesAsync() > 0
                ? new OperationResult(OperationResultType.Success, "用户“{0}”指派角色操作成功".FormatWith(user.UserName))
                : OperationResult.NoChanged;
        }

        /// <summary>
        /// 检测用户登录
        /// </summary>
        /// <param name="dto">包含登录的信息Dto</param>
        /// <returns>业务操作结果</returns>
        public OperationResult CheckLogin(LoginDto dto)
        {
            OperationResult re = new OperationResult(OperationResultType.NoChanged);
            var user = UserRepository.Entities.FirstOrDefault(c => c.UserName == dto.LoginName);

            if (user!=null)
            {
                if (user.IsLocked == false)
                {
                    if (UserManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, dto.LoginPwd) == PasswordVerificationResult.Success)
                    {
                        re.ResultType = OperationResultType.Success;
                        re.Message = "登录成功！";
                        re.Data = user;
                    }
                    else
                    {
                        re.ResultType = OperationResultType.ValidError;
                        re.Message = "密码错误！";
                    }
                }
                else
                {
                    re.ResultType = OperationResultType.ValidError;
                    re.Message = "当前用户已经禁用，无法登录，请联系管理员！";
                }
            }
            else
            {
                re.ResultType = OperationResultType.ValidError;
                re.Message = "系统不存在此用户！";
            }
            return re;
        }

        #endregion
    }
}