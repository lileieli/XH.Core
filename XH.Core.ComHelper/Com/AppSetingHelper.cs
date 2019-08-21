using Microsoft.Extensions.Configuration;
using System;
using XH.Core.Models.BaseModels;

namespace XH.Core.ComHelper.ComHelper
{
    /// <summary>
    /// 配置数据库连接字符串获取
    /// </summary>
    public class AppSetingHelper
    {
        //private static APPSetting _APPSett;
        //public static APPSetting APPSett => _APPSett;
        /// <summary>
        /// 取配置数据
        /// </summary>
        /// <param name="configuration"></param>
        //public void Initial()
        //{

        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Environment.CurrentDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    #region APPSetting
        //    APPSetting APPSett = new APPSetting
        //    { 
        //        Sqlconn = configuration["ConnectionStrings:Sqlconn"],
        //        Address = configuration["ConnectionStrings:Address"],
        //        IsOpenCache = configuration["Redis:IsOpenCache"],
        //        ReadWriteHosts = configuration["Redis:ReadWriteHosts"],
        //        ReadOnlyHosts = configuration["Redis:ReadOnlyHosts"]
        //    };
        //    _APPSett = APPSett;
        //    #endregion
        //}

        public static APPSetting APPSett;
        public void Initial()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
             APPSett = new APPSetting
            {
                Sqlconn = configuration["ConnectionStrings:Sqlconn"],
                Address = configuration["ConnectionStrings:Address"],
                IsOpenCache = configuration["Redis:IsOpenCache"],
                ReadWriteHosts = configuration["Redis:ReadWriteHosts"],
                ReadOnlyHosts = configuration["Redis:ReadOnlyHosts"],
                 FilePath = configuration["Redis:FilePath"]
             };
        }

    }
}
