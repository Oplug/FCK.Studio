using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;

namespace FCK.Studio.Web.Controllers
{
    public class SysManageController : Controller
    {
        // GET: SysManage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logs()
        {
            return View();
        }
        public ActionResult Databack()
        {
            return View();
        }
        public JsonResult Login(string LoginName, string Password)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            using (AdminsService admin = new AdminsService())
            {
                var count = admin.Reposity.GetAllList().Count;
                if (count <= 0) {
                    result.code = 500;
                    result.message = "No Init";
                }
                else
                {
                    var model = admin.Reposity.GetAllList().Where(o => o.LoginName == LoginName).FirstOrDefault();
                    if (model != null)
                    {
                        if (model.Password == AppBase.MD5(Password))
                        {
                            result.code = 100;
                            result.message = "success";
                            AppBase.SetCookie("AdminId", model.Id.ToString(), 1);
                        }
                        else
                        {
                            result.code = 101;
                            result.message = "Password error";
                        }
                    }
                    else
                    {
                        result.code = 102;
                        result.message = "Not exist";
                    }
                }
            }
            return Json(result);
        }

        public JsonResult InitSys(Tenants tenant, Admins admin)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                using (TenantsService Tenant = new TenantsService())
                {
                    int tenantId = Tenant.Reposity.InsertAndGetId(tenant);
                    if (tenantId > 0)
                    {
                        using (AdminsService Admin = new AdminsService())
                        {
                            admin.Password = AppBase.MD5(admin.Password);
                            admin.ControlTenants = tenantId.ToString();
                            Admin.Reposity.Insert(admin);
                        }
                    }
                }
                result.code = 100;
                result.message = "success";
            }
            catch(Exception err)
            {
                result.code = 500;
                result.message = err.Message;
            }
            return Json(result);
        }
    }
}