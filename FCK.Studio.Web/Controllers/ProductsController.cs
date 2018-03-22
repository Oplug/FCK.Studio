using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;

namespace FCK.Studio.Web.Controllers
{
    public class ProductsController : Controller, IControllerBase<Products, long>
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        public JsonResult GetModel(long id)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public JsonResult Del(long id)
        {
            throw new NotImplementedException();
        }

        public JsonResult InsertOrUpdate(Products input)
        {
            throw new NotImplementedException();
        }
    }
}