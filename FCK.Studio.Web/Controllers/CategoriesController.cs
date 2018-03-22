using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;

namespace FCK.Studio.Web.Controllers
{
    public class CategoriesController : Controller, IControllerBase<Categories, int>
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public JsonResult Del(int id)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public JsonResult InsertOrUpdate(Categories input)
        {
            throw new NotImplementedException();
        }
    }
}