using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhCity
    {
        public string CityId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int? Sort { get; set; }
        public byte? CityLevel { get; set; }
        public string ParentId { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
        public string Column10 { get; set; }
    }
}
