using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using XH.Core.ComHelper.ComHelper;

namespace XH.Core.ComHelper.Filter
{
    public class ExpetionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            LogHelper.WriteLogFile(context.ActionDescriptor.DisplayName,context.Exception);
        }
    }
}
