using AutoMapper;
using FCK.Studio.Application;
using FCK.Studio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ArticlesService article = new ArticlesService();
            string _title = Request.QueryString["tit"];
            if (_title == null)
            {
                _title = "关于我们";
            }
            Core.Articles model = new Core.Articles();
            model = article.Reposity.GetPageList(1, 1, (o => o.TenantId == tenant.Id && o.Title == _title)).datas.FirstOrDefault();
            if (model == null)
            {
                model = new Core.Articles();
                model.Title = _title;
                model.Contents = "正在建设中......";
                model.CreationTime = DateTime.Now;
            }
            return View(model);
        }
        public ActionResult Map()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult PartBuild()
        {
            return View();
        }
        public ActionResult Association()
        {
            return View();
        }
        public ActionResult PublicWelfare()
        {
            return View();
        }
        public ActionResult Service()
        {
            using (ArticlesService article = new ArticlesService())
            {
                var lists = article.GetArticleWithCate(1, 0, tenant.Id).datas
                    .Where(o => o.Category.CategoryName == "办事流程")
                    .ToList();
                return View(lists);
            }
        }
        public ActionResult Detail(long id)
        {
            ArticlesService article = new ArticlesService();
            var model = article.Reposity.Get(id);
            return View(model);
        }
        public ActionResult Portfolio()
        {
            return View();
        }
        [Filters.FilterCheckLogin]
        public ActionResult Election()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Regist()
        {
            return View();
        }
        public JsonResult GetArticleList(int page, int pageSize, string keywords = "", string cateindex = "", int isrec = -1)
        {
            ResultDto<List<Dto.ArticleDto>> result = new ResultDto<List<Dto.ArticleDto>>();
            ArticlesService article = new ArticlesService();
            var item = article.Reposity.GetPageList(page, pageSize, o => o.TenantId == tenant.Id && o.Category.CategoryIndex == cateindex);
            if (isrec >= 0)
            {
                bool rec = isrec > 0;
                item.datas = item.datas.Where(o => o.IsRecommend == rec).ToList();
            }
            result = Mapper.Map<ResultDto<List<Dto.ArticleDto>>>(item);
            article.Dispose();
            return Json(result);
        }
        public JsonResult GetMemberList()
        {
            MembersService ObjServ = new MembersService();
            var result = ObjServ.Reposity.GetPageList(1, 8, o => o.TenantId == tenant.Id);
            result.datas = result.datas.OrderByDescending(o => o.CreationTime).ToList();
            ObjServ.Dispose();
            return Json(result);
        }
        public JsonResult GetMember(int id = 0)
        {
            Core.Members model = new Core.Members();
            MembersService ObjServ = new MembersService();
            var result = ObjServ.Reposity.Get(id);
            if (result != null)
            {
                model = result;
            }
            else
            {
                model.TenantId = tenant.Id;
            }
            ObjServ.Dispose();
            return Json(model);
        }
        public JsonResult DoRegist(Core.Members input)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                MembersService ObjServ = new MembersService();
                var item1 = ObjServ.Reposity.GetAllList(o => o.UserName == input.UserName).Count();
                var item2 = ObjServ.Reposity.GetAllList(o => o.Mobile == input.Mobile && o.Mobile != null).Count();
                var item3 = ObjServ.Reposity.GetAllList(o => o.UserID == input.UserID && o.UserID != "00").Count();
                if (item1 > 0)
                {
                    result.code = 500;
                    result.message = "用户名已经存在";
                }
                else if (item2 > 0)
                {
                    result.code = 500;
                    result.message = "手机号已经存在";
                }
                else if (item3 > 0)
                {
                    result.code = 500;
                    result.message = "身份证号已经存在";
                }
                else
                {
                    Random rand = new Random();
                    int rank = rand.Next(1, 8);
                    input.Photo = "/Content/dist/img/user" + rank.ToString() + ".jpg";
                    input.Password = MD5(input.Password);
                    input.CreationTime = DateTime.Now;
                    input.TenantId = tenant.Id;
                    ObjServ.Reposity.Insert(input);
                    result.code = 100;
                    result.message = "ok";
                }
                ObjServ.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult DoLogin(string UserName, string Password)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                MembersService ObjServ = new MembersService();
                var model = ObjServ.Reposity.GetAllList(o => o.UserName == UserName || o.UserID == UserName || o.Mobile == UserName || o.Email == UserName).FirstOrDefault();
                if (model != null)
                {
                    if (model.Password != MD5(Password))
                    {
                        result.code = 500;
                        result.message = "密码错误";
                    }
                    else
                    {
                        result.code = 100;
                        result.message = "ok";
                        SetCookie("MemberId", model.Id.ToString(), 5);
                    }
                }
                else
                {
                    result.code = 500;
                    result.message = "用户不存在";
                }
                ObjServ.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }
    }
}