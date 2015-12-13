// -----------------------------------------------------------------------
//  <copyright file="DtoMappers.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-24 16:13</last-date>
// -----------------------------------------------------------------------

using AutoMapper;
using OSky.Core.Security;
using OSky.UI.Dtos.Flow;
using OSky.UI.Dtos.Identity;
using OSky.UI.Dtos.Infos;
using OSky.UI.Dtos.Security;
using OSky.UI.Models.Flow;
using OSky.UI.Models.Identity;
using OSky.UI.Models.Infos;


namespace OSky.UI.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class DtoMappers
    {
        /// <summary>
        /// 
        /// </summary>
        public static void MapperRegister()
        {
            //Common
            Mapper.CreateMap<DictionaryDto, Dictionary>();
            //Identity
            Mapper.CreateMap<OrganizationDto, Organization>();
            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<RoleDto, Role>();
            //Security
            Mapper.CreateMap<FunctionDto, Function>();
            Mapper.CreateMap<EntityInfoDto, EntityInfo>();
            //WorkFlow
            Mapper.CreateMap<FlowFormDto, WorkFlowForm>();
            Mapper.CreateMap<UserRoleMapDto, UserRoleMap>();
            Mapper.CreateMap<FlowDelegateDto, WorkFlowDelegation>();
        }
    }
}