using AutoMapper;
using FCK.Studio.Application;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using FCK.Studio.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class ArticlesController : BaseController, IControllerBase<Articles, long>
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            ArticlesService Article = new ArticlesService();
            var result = Article.GetListOrderByTime(page, pageSize, (o => o.TenantId == TenantId));
            var lists = Mapper.Map<ResultDto<List<Dto.ArticleDto>>>(result);
            return Json(lists);
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

        public JsonResult GetModelWithCategory(long id)
        {
            ArticleWithCategory result = new ArticleWithCategory();
            Articles model = new Articles();
            ArticlesService Article = new ArticlesService();
            var entity = Article.Reposity.FirstOrDefault(id);
            if (entity != null)
            {
                model = entity;
            }
            else
            {
                model.UpdateTime = DateTime.Now;
            }
            CategoriesService Category = new CategoriesService();

            CategoriesController cateCtrl = new CategoriesController();

            var lists = Category.Reposity.GetPageList(1, 0, (o => o.TenantId == TenantId));
            result.Article = Mapper.Map<Dto.ArticleInput>(model);
            result.Category = cateCtrl.GetCategoryTree(TenantId);
            return Json(result);
        }

        [ValidateInput(false)]
        public JsonResult CreateOrUpdate(ArticleInput model)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                ArticlesService ArticleRead = new ArticlesService();
                ArticlesService Article = new ArticlesService();
                CategoriesService Category = new CategoriesService();
                var input = Mapper.Map<Articles>(model);
                if (input.Id == 0)
                {
                    input.CreationTime = DateTime.Now;
                }
                else
                {
                    input.Category = Category.Reposity.Get(input.CategoryId);
                    //input.UpdateTime = DateTime.Now;
                    input.CreationTime = ArticleRead.Reposity.Get(input.Id).CreationTime;
                }
                input.Contents = HttpUtility.HtmlDecode(input.Contents);
                input.TenantId = TenantId;

                Article.Reposity.InsertOrUpdate(input);
                result.code = 100;
                result.datas = input.Id;
                result.message = "ok";
                Category.Dispose();
                Article.Dispose();
                ArticleRead.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult Del(long id)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                ArticlesService Article = new ArticlesService();
                Article.Reposity.Delete(id);
                result.code = 100;
                result.message = "success";
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        /**
         * 传入动作，action=top 置顶
         **/
        public JsonResult Top(long[] ids, string action)
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
                        input.IsTop = action.Equals("top") ? true : false;
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
        public JsonResult Recommend(long[] ids)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                using (ArticlesService Article = new ArticlesService())
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        long id = ids[i];
                        var input = Article.Reposity.Get(id);
                        input.IsRecommend = input.IsRecommend ? false : true;
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

        public JsonResult GetListByCategory(int page, int pageSize, string catename, int isrec)
        {
            using (ArticlesService article = new ArticlesService())
            {
                var lists = article.GetArticleWithCate(page, pageSize, TenantId).datas
                    .Where(o => o.Category.CategoryName == catename || o.Category.CategoryIndex == catename)
                    .ToList();
                if (isrec == 1)
                    lists = lists.Where(o => o.IsRecommend).ToList();
                return Json(lists);
            }
        }

        public JsonResult GetPageLists(int page, int pageSize, string keywords = "")
        {
            ArticlesService Article = new ArticlesService();
            ResultDto<List<Articles>> result = new ResultDto<List<Articles>>();
            if (string.IsNullOrEmpty(keywords))
            {
                result = Article.GetListOrderByTime(page, pageSize, (o => o.TenantId == TenantId));
            }
            else
                result = Article.GetListOrderByTime(page, pageSize, (o => o.TenantId == TenantId && o.Title.Contains(keywords)));
            var lists = Mapper.Map<ResultDto<List<Dto.ArticleDto>>>(result);
            Article.Dispose();
            return Json(lists);
        }

        public JsonResult InsertOrUpdate(Articles input)
        {
            throw new NotImplementedException();
        }
    }
}