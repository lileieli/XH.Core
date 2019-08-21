using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhDictInfo
    {
        public string StaticId { get; set; }
        public string ParentId { get; set; }
        public int? LevelXh { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
