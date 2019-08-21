using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XH.Core.Api.Controllers;
using XH.Core.ComHelper.Files;
using XH.Core.ComHelper.Filter;
using XH.Core.ComHelper.NoSQLHelper;
using XH.Core.IBLL.IResponse;
using XH.Core.Models.BaseModels.Common;

namespace XH.Core.Api.Areas.XH.Controllers
{

    [Area("XH")]
    public class LoginController : BaseController
    {
        private IXHUser _login;
        public LoginController(IXHUser login)
        {
            _login = login;
        }

        public async Task<ActionResult<bool>> Index()
        {
            Task<bool> r = Task.Run(() => { return false; });
            return await r;
        }
        #region 公共接口
        [LoginFilter]
        public async Task<ActionResult<SelectModel>> MethodRequest(RequestModel Param)
        {
            try
            {
                Task<SelectModel> result = Task.Run(() =>
                {

                    switch (Param.Method)
                    {
                        case "Register":
                            return Register(Param.Content);
                    }
                    return new SelectModel { State = 0, Message = "请检查参数是否正确" };
                });

                return await result;
            }
            catch (Exception ex)
            {
                return Json(new SelectModel { State = 0, Message = ex.Message });
            }
        }
        #endregion

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public SelectModel Register(string Content)
        {
            XhUser xHUser = new XhUser();
            xHUser = JsonConvert.DeserializeObject<XhUser>(Content);
            string FilePath = Upload.UploadFile(xHUser.Files, xHUser.Format);
            xHUser.UserPAddress = FilePath;
            int result = _login.Add(xHUser);
            return new SelectModel { State = result > 0 ? 1 : 0 };
        }

        /// 注册
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public SelectModel Login(string Content)
        {
            XhUser xHUser = new XhUser();
            xHUser = JsonConvert.DeserializeObject<XhUser>(Content);
            List<XhUser> result = _login.Get(xHUser);
            string token = RsToken(xHUser);
            return new SelectModel { State = result.Count > 0 ? 1 : 0, Content = token };
        }

        public string RsToken(XhUser xhUser)
        {
            string Token = new Guid().ToString().ToUpper();
            if (RedisHelper.Default.HashExists("user", xhUser.UserId))
            {
                RedisHelper.Default.HashRemove("user", xhUser.UserId);

            }
            RedisHelper.Default.HashSet("user", xhUser.UserId, Token);
            return Token;
        }
    }
}