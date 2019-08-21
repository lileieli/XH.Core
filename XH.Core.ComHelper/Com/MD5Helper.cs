using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace XH.Core.ComHelper.Com
{
  public  class MD5Helper
    {
        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UserMd5(string str)
        {
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.Unicode.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("x");
            }
            return pwd;
        } 
    }
}
