using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhCheckRecordDetail
    {
        public string RecordDetailId { get; set; }
        public string UserId { get; set; }
        public decimal? CanUseMoney { get; set; }
        public decimal? SummitMoney { get; set; }
        public decimal? LeftOverMoney { get; set; }
        public byte? RecordDetailType { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
