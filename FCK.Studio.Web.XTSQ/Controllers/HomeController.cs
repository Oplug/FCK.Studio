using FCK.Studio.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            ArticlesService article = new ArticlesService();
            var lists = article.Reposity.GetPageList(1, 10, (o => o.TenantId == tenant.Id)).datas;
            return View(lists);
        }
        public ActionResult About()
        {
            ArticlesService article = new ArticlesService();
            var model = article.Reposity.GetPageList(1, 1, (o => o.TenantId == tenant.Id && o.Title == "关于我们")).datas.FirstOrDefault();
            return View(model);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            ArticlesService article = new ArticlesService();
            var model = article.Reposity.Get(id);
            return View(model);
        }
    }
}