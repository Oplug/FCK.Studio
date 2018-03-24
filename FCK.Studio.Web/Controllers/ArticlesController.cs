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
    public class ArticlesController : Controller, IControllerBase<Articles, long>
    {
        // GET: Articles
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
            ArticlesService Article = new ArticlesService();
            var result = Article.Reposity.GetPageList(page, pageSize);
            return Json(result);
        }

        public JsonResult GetModel(long id)
        {
            Articles model = new Articles();
            ArticlesService Article = new ArticlesService();
            var result = Article.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
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
                else
                {
                    input.UpdateTime = DateTime.Now;
                }
                input.Contents = HttpUtility.UrlDecode(input.Contents);
                var result = Article.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult Del(long id)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try {
                ArticlesService Article = new ArticlesService();
                Article.Reposity.Delete(id);
                result.code = 100;
                result.message = "success";
            }
            catch(Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        /**
         * 传入动作，action=top 置顶
         **/
        public JsonResult Top(long[] ids,string action)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                using (ArticlesService Article = new ArticlesService())
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        long id = ids[i];
                        var input = Article.Reposity.FirstOrDefault(id);
                        input.IsTop = action.Equals("top")?true:false;
                        Article.Reposity.InsertOrUpdate(input);
                    }
                    result.code = 100;
                    result.message = "success";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        /**
         * 传入动作，action=hot 热门
         **/
        public JsonResult Hot(long[] ids, string action)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                using (ArticlesService Article = new ArticlesService())
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        long id = ids[i];
                        var input = Article.Reposity.FirstOrDefault(id);
                        input.IsHot = action.Equals("hot") ? true : false;
                        Article.Reposity.InsertOrUpdate(input);
                    }
                    result.code = 100;
                    result.message = "success";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        /**
         * 传入动作，action=recommend 推荐
         **/
        public JsonResult Recommend(long[] ids, string action)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                using (ArticlesService Article = new ArticlesService())
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        long id = ids[i];
                        var input = Article.Reposity.FirstOrDefault(id);
                        input.IsRecommend = action.Equals("recommend") ? true : false;
                        Article.Reposity.InsertOrUpdate(input);
                    }
                    result.code = 100;
                    result.message = "success";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }
    }
}