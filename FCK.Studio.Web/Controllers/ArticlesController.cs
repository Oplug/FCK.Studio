using AutoMapper;
using FCK.Studio.Application;
using FCK.Studio.Core;
using FCK.Studio.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetModel(int id)
        {
            Articles model = new Articles();
            ArticlesService Article = new ArticlesService();
            var result = Article.Reposity.FirstOrDefault(id);
            if (result != null)
                model = result;
            return Json(model);
        }
        public JsonResult InsertOrUpdate(Articles input)
        {
            using (ArticlesService Article = new ArticlesService())
            {
                if (input.Id == 0)
                {
                    input.CreationTime = DateTime.Now;
                    input.TenantId = 1;
                    input.CategoryId = 1;
                }
                input.Contents = HttpUtility.UrlDecode(input.Contents);
                var result = Article.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            ArticlesService Article = new ArticlesService();
            var result = Article.Reposity.GetPageList(page, pageSize);
            return Json(result);
        }
    }
}