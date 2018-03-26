using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 站点ID
        /// </summary>
        public int TenantId = AppBase.GetTenantId();
    }
}