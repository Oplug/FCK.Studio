using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;
using FCK.Studio.Web.Dto;

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
        
        public JsonResult GetLists(int page, int pageSize)
        {
            CategoriesService Category = new CategoriesService();
            var result = Category.Reposity.GetPageList(page, pageSize);
            return Json(result);
        }

        public JsonResult GetModel(int id)
        {
            Categories model = new Categories();
            CategoriesService Category = new CategoriesService();
            var result = Category.Reposity.FirstOrDefault(id);
            if (result != null)
                model = result;
            return Json(model);
        }

        public JsonResult GetModelWithParents(int id)
        {
            CategoryWithParents dto = new CategoryWithParents();
            Categories entity = new Categories();
            CategoriesService Category = new CategoriesService();
            var result = Category.Reposity.FirstOrDefault(id);
            if (result != null)
                entity = result;
            dto.Category = entity;
            var lists = Category.Reposity.GetAllList();
            dto.ParentLists = lists;
            return Json(dto);
        }

        public JsonResult InsertOrUpdate(Categories input)
        {
            using (CategoriesService Category = new CategoriesService())
            {
                if (input.Id == 0)
                {
                    input.TenantId = 1;
                }
                else
                {
                }
                var result = Category.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult Del(int id)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                CategoriesService Category = new CategoriesService();
                Category.Reposity.Delete(id);
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