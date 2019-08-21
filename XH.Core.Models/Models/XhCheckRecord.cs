using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhCheckRecord
    {
        public string RecordId { get; set; }
        public decimal? TotalMoney { get; set; }
        public decimal? AppMoney { get; set; }
        public byte? IsAbnormal { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
