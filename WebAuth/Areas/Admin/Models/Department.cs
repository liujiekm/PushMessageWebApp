﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAuth.Models
{
    /// <summary>
    ///     机构
    /// </summary>
    public class Department
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Department" /> class.
        /// </summary>
        public Department()
        {
            this.Users = new List<UserDepartment>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     机构编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     机构名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     下辖用户列表
        /// </summary>
        public virtual ICollection<UserDepartment> Users { get; set; }

        #endregion
    }
}