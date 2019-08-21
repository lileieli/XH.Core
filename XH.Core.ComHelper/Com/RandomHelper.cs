using System;
using System.Collections.Generic;
using System.Text;

namespace XH.Core.ComHelper.Com
{
   public class RandomHelper
    {
        public static string Random(int min=1000,int  max=9999)
        {
            return new Random().Next(min,max).ToString();
          
        }
    }
}
