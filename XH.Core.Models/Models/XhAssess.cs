using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhAssess
    {
        public string AssessId { get; set; }
        public string GoodsId { get; set; }
        public string UserId { get; set; }
        public string AssessContent { get; set; }
        public byte? AssessSatisfaction { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
