using System;
using System.Collections.Generic;
using System.Text;

namespace XH.Core.Models.BaseModels
{
    /// <summary>
    /// 系统设置
    /// </summary>
   public class APPSetting
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Sqlconn { get; set; }
        /// <summary>
        /// 日志路径
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 是否打开缓存1是0否
        /// </summary>
        public string IsOpenCache { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReadWriteHosts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReadOnlyHosts { get; set; }
        /// <summary>
        ///图片存储地址
        /// </summary>
        public string FilePath { get; set; }
    }
  
}
