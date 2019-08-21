using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhAccount
    {
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public decimal? AccountMoney { get; set; }
        public decimal? CanUserMoney { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
