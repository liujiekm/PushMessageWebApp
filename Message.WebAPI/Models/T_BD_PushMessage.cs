//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Message.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class T_BD_PushMessage
    {
        public int Id { get; set; }
        public string MsgContent { get; set; }
        public string MsgTitle { get; set; }
        public int MsgType { get; set; }
        public string MsgSendType { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> ExpirationTime { get; set; }
        public Nullable<int> Userid { get; set; }
        public bool IsRead { get; set; }

    }



}