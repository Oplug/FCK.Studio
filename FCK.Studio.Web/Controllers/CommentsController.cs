using FCK.Studio.Core;
using FCK.Studio.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class CommentsController : Controller, IControllerBase<Comments, long>
    {

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            CommentsService Comment = new CommentsService();
            var result = Comment.Reposity.GetPageList(page, pageSize);
            return Json(result);
        }

        public JsonResult GetModel(long id)
        {
            Comments model = new Comments();
            CommentsService Comment = new CommentsService();
            var result = Comment.Reposity.FirstOrDefault(id);
            if (result != null)
                model = result;
            return Json(model);
        }

        public JsonResult InsertOrUpdate(Comments input)
        {
            using (CommentsService Comment = new CommentsService())
            {
                if (input.Id == 0)
                {
                    input.TenantId = 1;
                }
                else
                {
                    
                }
                input.Contents = HttpUtility.UrlDecode(input.Contents);
                var result = Comment.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult Del(long id)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                CommentsService Comment = new CommentsService();
                Comment.Reposity.Delete(id);
                result.code = 100;
                result.message = "success";
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

    }
}