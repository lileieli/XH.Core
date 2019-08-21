using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhAcceptance
    {
        public string AcceptanceId { get; set; }
        public string AcceptanceByUser { get; set; }
        public string GoodsId { get; set; }
        public byte? AcceptanceState { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
