using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;
using FCK.Studio.Web.Dto;
using FCK.Studio.Web.Filters;
using FCK.Studio.Dto;
using AutoMapper;

namespace FCK.Studio.Web.Controllers
{
    [FilterAdminLogin]
    public class CategoriesController : BaseController, IControllerBase<Categories, int>
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
            var result = Category.Reposity.GetPageList(page, pageSize, (o => o.TenantId == TenantId));
            Category.Dispose();
            return Json(result);
        }

        public JsonResult GetTreeList()
        {
            ResultDto<List<CategoryTree>> result = new ResultDto<List<CategoryTree>>();
            var lists = GetCategoryTree();
            result.datas = lists;
            result.code = 100;
            result.total = lists.Count;
            return Json(result);
        }

        public List<CategoryTree> GetCategoryTree()
        {
            CategoriesService Category = new CategoriesService();
            var result = Category.Reposity.GetAllList(o => o.TenantId == TenantId);
            List<Categories> lists = new List<Categories>();
            CreateTree(lists, result);
            var elist = Mapper.Map<List<Dto.CategoryTree>>(lists);
            foreach (var item in elist)
            {
                string prev = "";
                if (item.Level > 0)
                {
                    prev = "└";
                    for (int i = 0; i < item.Level; i++)
                    {
                        prev += "┴";
                    }
                }
                item.PrevStr = prev;
            }
            Category.Dispose();
            return elist;
        }

        public void CreateTree(List<Categories> lists, List<Categories> Categorys, int partntid = 0)
        {
            var items = Categorys.Where(o => o.ParentId == partntid).ToList();
            foreach (var item in items)
            {
                lists.Add(item);
                if (Categorys.Where(o => o.ParentId == item.Id).Count() > 0)
                {
                    CreateTree(lists, Categorys, item.Id);
                }
            }
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
            dto.ParentLists = GetCategoryTree();
            return Json(dto);
        }

        public JsonResult InsertOrUpdate(Categories input)
        {
            List<Categories> AllCate = new List<Categories>();
            using (CategoriesService Category = new CategoriesService())
            {
                AllCate = Category.Reposity.GetAllList(o => o.TenantId == TenantId);
            }
            using (CategoriesService Category = new CategoriesService())
            {                
                input.TenantId = TenantId;
                input.Level = CsmLevel(input.ParentId, AllCate);
                var result = Category.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public int CsmLevel(int parentid, List<Categories> Categorys, int result = 0)
        {
            var parent = Categorys.Where(o => o.Id == parentid).FirstOrDefault();
            if (parent == null)
            {
                return result;
            }
            else
            {
                result++;
                return CsmLevel(parent.ParentId, Categorys, result);
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