// -----------------------------------------------------------------------
//  <copyright file="FunctionUserMapDto.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <site>http://www.OSky.org</site>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-08-04 13:48</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Security.Dtos;
using OSky.Core.Security.Models;


namespace OSky.UI.Dtos.Security
{
    /// <summary>
    /// 功能用户映射DTO
    /// </summary>
    public class FunctionUserMapDto : FunctionUserMapBaseDto<int, Guid, int>
    { }
}