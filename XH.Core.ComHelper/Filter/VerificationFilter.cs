using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using XH.Core.ComHelper.Com;
using XH.Core.ComHelper.ComHelper;
using XH.Core.ComHelper.NoSQLHelper;
using XH.Core.Models.BaseModels.Common;

namespace XH.Core.ComHelper.Filter
{

    public class VerificationFilter : Attribute, IActionFilter
    {
        /// <summary>
        /// 执行Action后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        /// <summary>
        /// 执行Action前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //获取参数判断有没有Token
            IDictionary<string, object> Content = context.ActionArguments;
            try
            {
                foreach (object item in Content.Values)
                {
                    RequestModel Request = item as RequestModel;
                    if (Request != null)
                    {
                        if (string.IsNullOrEmpty(Request.Content))
                        {
                            throw new Exception("参数Content不能为空");
                        }
                        else if (string.IsNullOrEmpty(Request.Method))
                        {
                            throw new Exception("参数Method不能为空");
                        }
                        else if (string.IsNullOrEmpty(Request.Sign))
                        {
                            throw new Exception("参数Sign不能为空");
                        }
                        else if (string.IsNullOrEmpty(Request.Token))
                        {
                            throw new Exception("参数Token不能为空");
                        }
                        else if (DeBug.DeBug.DeBugs)
                        {
                            if (Request.Sign != MD5Helper.UserMd5(Request.Content))
                            {
                                throw new Exception("签名效验不通过");
                            }
                        }
                        //string key = RedisHelper.Default.StringGet()
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.WriteLogFile("LoginFilter-OnActionExecuting", ex);
                throw ex;
            }
        }


    }
}
