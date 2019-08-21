using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhCredit
    {
        public string CreditId { get; set; }
        public string UserId { get; set; }
        public byte? UserType { get; set; }
        public int? NumberOfTimes { get; set; }
        public int? IntegralNum { get; set; }
        public int? CreditNum { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
