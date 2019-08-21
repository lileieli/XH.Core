using System;
using System.Collections.Generic;
using System.Linq;
using XH.Core.Api;
using XH.Core.IBLL.IResponse;
using XH.Core.Models.BaseModels.Common;

namespace XH.Core.DAL.Login
{
    public class XHUserDAL : IXHUser
    {
        public int Add(XhUser entity)
        {
            using (XHBaseContext db = new XHBaseContext())
            {
                db.XhUser.Add(entity);

                return db.SaveChanges();
            }
        }

        public int Delete(XhUser entity)
        {
            throw new NotImplementedException();
        }

        public List<XhUser> Get(XhUser entity)
        {
            using (XHBaseContext db = new XHBaseContext())
            {
                return db.XhUser.Where(p => p.UserId == entity.UserId && p.UserPassword == entity.UserPassword).ToList();

            }
        }

        public Tuple<List<XhUser>, int> GetByPage(XhUser entity, PageModel page)
        {
            throw new NotImplementedException();
        }

        public int Update(XhUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
