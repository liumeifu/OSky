﻿// -----------------------------------------------------------------------
//  <copyright file="DtoMappers.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-03-24 16:13</last-date>
// -----------------------------------------------------------------------

using AutoMapper;

using OSky.Core.Security;
using OSky.UI.Dtos.Identity;
using OSky.UI.Dtos.Security;
using OSky.UI.Models.Identity;


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
            //Identity
            Mapper.CreateMap<OrganizationDto, Organization>();
            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<RoleDto, Role>();
            //Security
            Mapper.CreateMap<FunctionDto, Function>();
            Mapper.CreateMap<EntityInfoDto, EntityInfo>();
        }
    }
}