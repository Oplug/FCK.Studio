using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;
using AutoMapper;
using FCK.Studio.Dto;
using FCK.Studio.Web.Filters;

namespace FCK.Studio.Web.Controllers
{
    [FilterAdminLogin]
    public class TenantsController : Controller, IControllerBase<Tenants, int>
    {
        // GET: Tenants
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
            Tenants model = new Tenants();
            TenantsService Tenant = new TenantsService();
            var result = Tenant.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
            return Json(model);
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            TenantsService Tenant = new TenantsService();
            var result = Tenant.Reposity.GetPageList(page, pageSize);
            var lists = Mapper.Map<ResultDto<List<Dto.TenantDto>>>(result);
            return Json(lists);
        }

        public JsonResult GetListsByAdmin()
        {
            ResultDto<List<Dto.TenantDto>> lists = new ResultDto<List<Dto.TenantDto>>();
            string AdminId = AppBase.CookieVal("AdminId");
            AdminsService adminServ = new AdminsService();
            var admin = adminServ.Reposity.Get(int.Parse(AdminId));
            if (admin != null && admin.ControlTenants != null)
            {
                List<int> tenantIds = new List<int>();
                foreach (var item in admin.ControlTenants.Split(','))
                {
                    tenantIds.Add(int.Parse(item));
                }
                TenantsService Tenant = new TenantsService();
                var result = Tenant.Reposity.GetPageList(1, 0, (o => tenantIds.Contains(o.Id)));
                lists = Mapper.Map<ResultDto<List<Dto.TenantDto>>>(result);
            }
            return Json(lists);
        }

        public JsonResult InsertOrUpdate(Tenants input)
        {
            using (TenantsService Tenant = new TenantsService())
            {
                if(input.Id==0)
                {
                    input.CreationTime = DateTime.Now;
                    input.SecretKey = Guid.NewGuid();
                }
                var result = Tenant.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult Del(int id)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                TenantsService Tenant = new TenantsService();
                Tenant.Reposity.Delete(id);
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