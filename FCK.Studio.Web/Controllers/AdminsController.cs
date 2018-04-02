using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;
using AutoMapper;
using FCK.Studio.Dto;

namespace FCK.Studio.Web.Controllers
{
    public class AdminsController : Controller, IControllerBase<Admins, int>
    {
        // GET: Admins
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
            Admins model = new Admins();
            AdminsService Admin = new AdminsService();
            var result = Admin.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
            return Json(model);
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            AdminsService Admin = new AdminsService();
            var result = Admin.Reposity.GetPageList(page, pageSize);
            var lists = Mapper.Map<ResultDto<List<Dto.AdminDto>>>(result);
            return Json(lists);
        }
       
        public JsonResult InsertOrUpdate(Admins input)
        {
            using (AdminsService Admin = new AdminsService())
            {
                if (input.Id == 0)
                {
                    input.CreationTime = DateTime.Now;
                }
                var result = Admin.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult Del(int id)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                AdminsService Admin = new AdminsService();
                Admin.Reposity.Delete(id);
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