using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;

namespace FCK.Studio.Web.Controllers
{
    public class MembersController : Controller, IControllerBase<Members, int>
    {
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public JsonResult GetModel(int id)
        {
            Members model = new Members();
            MembersService Member = new MembersService();
            var result = Member.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
            return Json(model);
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            MembersService Member = new MembersService();
            var result = Member.Reposity.GetPageList(page, pageSize);
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Members input)
        {
            using (MembersService Member = new MembersService())
            {
                if (input.Id == 0)
                {
                    input.CreationTime = DateTime.Now;
                    input.TenantId = 1;
                }
                else
                {
                    //input.UpdateTime = DateTime.Now;
                }
                var result = Member.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult Del(int id)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                MembersService Member = new MembersService();
                Member.Reposity.Delete(id);
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