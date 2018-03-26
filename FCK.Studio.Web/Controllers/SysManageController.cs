using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                var model = admin.Reposity.GetAllList().Where(o => o.LoginName == LoginName).FirstOrDefault();
                if (model != null)
                {
                    if (model.Password == Password)
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
            return Json(result);
        }

        public JsonResult Logout()
        {
            var result = AppBase.DelCookie("AdminId", "");
            return Json(result);
        }
    }
}