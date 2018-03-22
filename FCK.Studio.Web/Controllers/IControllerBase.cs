using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public interface IControllerBase<T, TPrimaryKey>
    {
        JsonResult GetModel(TPrimaryKey id);
        JsonResult InsertOrUpdate(T input);
        JsonResult GetLists(int page, int pageSize);
        JsonResult Del(TPrimaryKey id);

    }
}
