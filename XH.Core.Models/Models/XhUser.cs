using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhUser
    {
       

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserPassword { get; set; }
        public string UserIdCard { get; set; }
        public string UserPicture { get; set; }
        public string UserType { get; set; }
        public string UserAddresss { get; set; }
        public int? UserAge { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
        public string UserPAddress { get; set; }
       
    }
}
