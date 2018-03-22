using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class CommentsController : Controller, IControllerBase<Comments, long>
    {
        public JsonResult Del(long id)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetModel(long id)
        {
            throw new NotImplementedException();
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertOrUpdate(Comments input)
        {
            throw new NotImplementedException();
        }
    }
}