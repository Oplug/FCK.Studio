using AutoMapper;
using FCK.Studio.Application;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using FCK.Studio.Web.Dto;
using FCK.Studio.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class HomeController : BaseController
    {
        [FilterAdminLogin]
        public ActionResult Index()
        {
            AdminWithTenant models = new AdminWithTenant();
            if (AdminId > 0)
            {
                using (AdminsService admin = new AdminsService())
                {
                    var model = admin.Reposity.Get(AdminId);
                    models.Admin = Mapper.Map<AdminDto>(model);
                }
                using (TenantsService tenantS = new TenantsService())
                {
                    var model = tenantS.Reposity.Get(TenantId);
                    if (model != null)
                    {
                        models.Tenant = Mapper.Map<TenantDto>(model);
                    }
                    else
                    {
                        models.Tenant = new TenantDto()
                        {
                            TenantName = "暂无站点",
                            Id = 0
                        };
                    }
                }
            }
            return View(models);
        }
        public ActionResult Errors()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        public JsonResult Logout()
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                AppBase.DelCookie("AdminId", "");
                AppBase.DelCookie("TenantId", "");
                result.code = 100;
            }
            catch(Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }            
            return Json(result);
        }
        [FilterAdminLogin]
        public ActionResult Dashboard()
        {
            ArticlesService ArtServ = new ArticlesService();
            MembersService MembServ = new MembersService();
            SignUpBespeakService SignServ = new SignUpBespeakService();
            ProductsService ProdServ = new ProductsService();
            ViewBag.ArticleNum = ArtServ.Reposity.GetAllList(o => o.TenantId == TenantId).Count;
            ViewBag.MemberNum = MembServ.Reposity.GetAllList(o => o.TenantId == TenantId).Count;
            ViewBag.SignNum = SignServ.Reposity.GetAllList(o => o.TenantId == TenantId).Count;
            ViewBag.ProdNum = ProdServ.Reposity.GetAllList(o => o.TenantId == TenantId).Count;
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public JsonResult SwitchTenant(int tenantId)
        {
            using (TenantsService tenantS = new TenantsService())
            {
                var tenant = tenantS.Reposity.Get(tenantId);
                if (tenant != null)
                {
                    AppBase.SetCookie("TenantId", tenantId.ToString(), 1);
                }
                return Json(tenant);
            }
        }

        public ActionResult _PartialLeftSide()
        {
            List<int> powers = new List<int>();
            string AdminName = "";
            using (AdminsService admin = new AdminsService())
            {
                var model = admin.Reposity.Get(AdminId);
                if (model != null && model.Powers != null)
                {
                    AdminName = model.LoginName;
                    foreach (var item in model.Powers.Split(','))
                    {
                        powers.Add(int.Parse(item));
                    }
                }
            }
            CategoriesController CateCtrl = new CategoriesController();
            var lists = CateCtrl.GetCategoryTree();          
            
            lists = lists.Where(o => powers.Contains(o.Id)).ToList();
            ViewBag.Admin = AdminName;
            return PartialView(lists);
        }
    }
}