using AutoMapper;
using FCK.Studio.Application;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using FCK.Studio.Web.XTSQ.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetTreeList(string layout = "", string parentcate = "")
        {
            ResultDto<List<CategoryTree>> result = new ResultDto<List<CategoryTree>>();
            var lists = GetCategoryTree(tenant.Id);
            if (!string.IsNullOrEmpty(layout))
            {
                lists = lists.Where(o => o.Layout == layout).ToList();
            }
            if (!string.IsNullOrEmpty(parentcate))
            {
                var parent = lists.Where(o => o.CategoryName == parentcate || o.CategoryIndex == parentcate).FirstOrDefault();
                if (parent != null)
                {
                    lists = lists.Where(o => o.ParentId == parent.Id).ToList();
                }
            }
            result.datas = lists;
            result.code = 100;
            result.total = lists.Count;
            return Json(result);
        }

        public List<CategoryTree> GetCategoryTree(int tenandId = 0)
        {
            CategoriesService Category = new CategoriesService();
            var result = Category.Reposity.GetAllList();
            if (tenandId > 0)
            {
                result = result.Where(o => o.TenantId == tenandId).ToList();
            }
            
            List<Categories> lists = new List<Categories>();
            CreateTree(lists, result);
            var elist = Mapper.Map<List<CategoryTree>>(lists);
            foreach (var item in elist)
            {
                string prev = "";
                if (item.Level > 0)
                {
                    prev = "└";
                    for (int i = 0; i < item.Level; i++)
                    {
                        prev += "─";
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
    }
}