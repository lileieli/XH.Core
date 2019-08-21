using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhPayBusiness
    {
        public string PayId { get; set; }
        public byte? PayType { get; set; }
        public byte? PayWay { get; set; }
        public decimal? PayMany { get; set; }
        public string PayByDataSource { get; set; }
        public byte? PayState { get; set; }
        public string PaythirdId { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
