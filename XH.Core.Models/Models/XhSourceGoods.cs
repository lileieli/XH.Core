using System;
using System.Collections.Generic;

namespace XH.Core.Api
{
    public partial class XhSourceGoods
    {
        public string GoodsId { get; set; }
        public string GoodsByUser { get; set; }
        public string GoodsName { get; set; }
        public int? GoodByPerson { get; set; }
        public decimal? GoodsWeight { get; set; }
        public DateTime? GoodsNeedTime { get; set; }
        public decimal? GoodsPrice { get; set; }
        public byte? GoodsIsFinish { get; set; }
        public string GoodByAddress { get; set; }
        public byte? GoodsIsUrgent { get; set; }
        public byte? GoodsSyate { get; set; }
        public string Remakes { get; set; }
        public DateTime? OperateTime { get; set; }
        public string OperateUser { get; set; }
    }
}
