using System;
using System.Collections.Generic;
using System.Text;

namespace XH.Core.Models.BaseModels.Common
{
   public class RequestModel
    {
        /// <summary>
        /// 请求参数
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 请求方法
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        public string Sign { get; set; }

    }
}
