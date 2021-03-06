﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Web;
using WebAuth.Models;
using WebAuth.Areas.Admin.Controllers;
using WebAuth.Helper;
using System.Threading;

namespace WebAuth.Controllers
{
    /// <summary>
    /// 基础类
    /// </summary>
    [IdentityAuthorize(Roles = "Administrators")]
    public abstract partial class BaseAdminController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAdminController"/> class.
        /// </summary>
        public BaseAdminController()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAdminController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        public BaseAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private ApplicationUserManager userManager;
        /// <summary>
        /// Gets the _user manager.
        /// </summary>
        /// <value>
        /// The _user manager.
        /// </value>
        protected ApplicationUserManager _userManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        private ApplicationRoleManager roleManager;
        /// <summary>
        /// Gets the _role manager.
        /// </summary>
        /// <value>
        /// The _role manager.
        /// </value>
        protected ApplicationRoleManager _roleManager
        {
            get
            {
                return roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                roleManager = value;
            }
        }

        /// <summary>
        /// The database
        /// </summary>
        private ApplicationDbContext db;
        /// <summary>
        /// Gets the _DB.
        /// </summary>
        /// <value>
        /// The _DB.
        /// </value>
        protected ApplicationDbContext _db
        {
            get
            {
                return db ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                db = value;
            }
        }
        /// <summary>
        /// 缓存key
        /// </summary>
        private readonly static string _permissionKey = "PermissionsOfAssembly";
        /// <summary>
        /// 程序集中权限集合
        /// </summary>
        protected IEnumerable<ApplicationPermission> _permissionsOfAssembly
        {
            get
            {
                var permissions = HttpContext.Application.Get(_permissionKey) as IEnumerable<ApplicationPermission>;
                if (permissions == null)
                {
                    //取程序集中全部权限
                    permissions = ActionPermissionService.GetAllActionByAssembly();
                    //添加到缓存
                    HttpContext.Application.Add(_permissionKey, permissions);
                }
                return permissions;
            }
        }

    }
}