﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OSky.Core.Data.Entity.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OSky.Core.Data.Entity.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 上下文类型“{0}”不是IUnitOfWork接口的派生类 的本地化字符串。
        /// </summary>
        internal static string ContextTypeNotIUnitOfWorkType {
            get {
                return ResourceManager.GetString("ContextTypeNotIUnitOfWorkType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 类型“{0}”不是有效的上下文初始化类型 的本地化字符串。
        /// </summary>
        internal static string DatabaseInitializer_TypeNotDatabaseInitializer {
            get {
                return ResourceManager.GetString("DatabaseInitializer_TypeNotDatabaseInitializer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 名称为“{0}”的数据库连接串不存在 的本地化字符串。
        /// </summary>
        internal static string DbContextBase_ConnectionStringNameNotExist {
            get {
                return ResourceManager.GetString("DbContextBase_ConnectionStringNameNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 上下文“{0}”初始化失败，实体映射程序集不存在 的本地化字符串。
        /// </summary>
        internal static string DbContextInitializerBase_MapperAssembliesIsEmpty {
            get {
                return ResourceManager.GetString("DbContextInitializerBase_MapperAssembliesIsEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 实体类型“{0}”未映射到上下文中，请为实体派生 EntityConfigurationBase&lt;&gt; 类型，使之能被数据上下文加载。 的本地化字符串。
        /// </summary>
        internal static string DbContextManager_EntityTypeNotMaptoDbContext {
            get {
                return ResourceManager.GetString("DbContextManager_EntityTypeNotMaptoDbContext", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 类型“{0}”不是 DbContextBase&lt;&gt; 类型的派生类 的本地化字符串。
        /// </summary>
        internal static string DbContextManager_TypeNotDbContextType {
            get {
                return ResourceManager.GetString("DbContextManager_TypeNotDbContextType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 类型“{0}”不是实体类型 的本地化字符串。
        /// </summary>
        internal static string DbContextManager_TypeNotEntityType {
            get {
                return ResourceManager.GetString("DbContextManager_TypeNotEntityType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 实体类“{0}”所属的上下文“{1}”获取失败 的本地化字符串。
        /// </summary>
        internal static string DbContextTypeResolver_DbContextResolveFailed {
            get {
                return ResourceManager.GetString("DbContextTypeResolver_DbContextResolveFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 仓储中的 {0} 方法不支持事务操作 的本地化字符串。
        /// </summary>
        internal static string Repository_MethodNotSupportedTransaction {
            get {
                return ResourceManager.GetString("Repository_MethodNotSupportedTransaction", resourceCulture);
            }
        }
    }
}
