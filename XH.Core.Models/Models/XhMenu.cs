using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhMenu
    {
        public byte[] MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuCode { get; set; }
        public string MenuClassify { get; set; }
        public string MenuParentId { get; set; }
        public int? Sort { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
        public string Column10 { get; set; }
    }
}
