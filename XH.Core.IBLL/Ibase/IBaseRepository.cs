using System;
using System.Collections.Generic;
using XH.Core.Models.BaseModels.Common;

namespace XH.Core.IBLL.Ibase
{
    public interface IBaseRepository<T> where T : new()
    {
        int Add(T entity);
        int Delete(T entity);
        int Update(T entity);
        List<T> Get(T entity);

        Tuple<List<T>, int> GetByPage(T entity, PageModel page);

    }

}
