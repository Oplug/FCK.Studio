using FCK.Studio.Application;
using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Controllers
{
    public class BaseController : Controller
    {
        public string AppSecretKey = "ca56f1ac-2f12-4884-ab53-49af1dfbaab5";
        public Tenants tenant;
        public BaseController()
        {
            tenant = new Tenants();
            try {
                TenantsService tenantS = new TenantsService();
                tenant = tenantS.Reposity.GetAllList(o => o.SecretKey == new Guid(AppSecretKey)).FirstOrDefault();
            } catch { } 
        }
    }
}