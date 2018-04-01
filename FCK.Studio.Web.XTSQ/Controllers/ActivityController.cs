using FCK.Studio.Application;
using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult SignUp(long id)
        {
            using (ArticlesService articleS = new ArticlesService())
            {
                var model = articleS.Reposity.Get(id);
                return View(model);
            }
        }

        public ActionResult Bespeak(long id)
        {
            using (ArticlesService articleS = new ArticlesService())
            {
                var model = articleS.Reposity.Get(id);
                return View(model);
            }
        }

        public JsonResult GetModel(long id)
        {
            SignUpBespeak model = new SignUpBespeak();
            using (SignUpBespeakService subkS = new SignUpBespeakService())
            {
                var result = subkS.Reposity.FirstOrDefault(id);
                if (result != null)
                {
                    model = result;
                }
            }                
            return Json(model);
        }
        public JsonResult InsertOrUpdate(SignUpBespeak input)
        {
            Dto.ResultDto<SignUpBespeak> result = new Dto.ResultDto<SignUpBespeak>();
            using (SignUpBespeakService subkS = new SignUpBespeakService())
            {
                try
                {
                    var ishas = subkS.Reposity.GetPageList(1, 0, (o => o.UserName == input.UserName && o.ActvID == input.ActvID)).total;
                    if (ishas > 0)
                    {
                        result.code = 101;
                        result.message = "Cannot repeat or make an appointment";
                    }
                    else
                    {
                        if (input.Id == 0)
                        {
                            input.CreationTime = DateTime.Now;
                        }
                        var data = subkS.Reposity.InsertOrUpdate(input);
                        result.code = 100;
                        result.message = "success";
                    }
                }
                catch(Exception ex)
                {
                    result.code = 500;
                    result.message = ex.Message;
                }
                            
                return Json(result);
            }
        }
    }
}