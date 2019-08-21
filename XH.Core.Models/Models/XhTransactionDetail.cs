using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhTransactionDetail
    {
        public string DetailId { get; set; }
        public string GoodsId { get; set; }
        public string UserId { get; set; }
        public byte? IsFinish { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
