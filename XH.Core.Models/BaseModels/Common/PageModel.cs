using System;
using System.Collections.Generic;
using System.Text;

namespace XH.Core.Models.BaseModels.Common
{
   public class PageModel
    {
        /// <summary>
        /// 显示数量
        /// </summary>
        public string PageSize { get; set; }
        /// <summary>
        /// 显示索引
        /// </summary>
        public string PageIndex { get; set; }
       /// <summary>
       /// 总数据
       /// </summary>
        public string PageTotal { get; set; }
    }
}
