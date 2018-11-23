using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;
using AutoMapper;
using FCK.Studio.Dto;
using FCK.Studio.Web.Dto;

namespace FCK.Studio.Web.Controllers
{
    public class AdminsController : Controller, IControllerBase<Admins, int>
    {
        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
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

        public JsonResult GetModelWithSelect(int id)
        {
            AdminWithSelect result = new AdminWithSelect();
            AdminsService AdminServ = new AdminsService();
            var model = AdminServ.Reposity.FirstOrDefault(id);
            if (model == null)
                model = new Admins();
            result.Admin = model;
            List<int> tenantIds = new List<int>();
            if (model.ControlTenants != null)
            {
                foreach (var item in model.ControlTenants.Split(','))
                {
                    tenantIds.Add(int.Parse(item));
                }
            }

            List<int> powers = new List<int>();
            if (model.Powers != null)
            {
                foreach (var item in model.Powers.Split(','))
                {
                    powers.Add(int.Parse(item));
                }
            }

            TenantsService TenServ = new TenantsService();
            var tenants = TenServ.Reposity.GetAllList();
            List<TenantSelect> TenantList = new List<TenantSelect>();
            foreach (var item in tenants)
            {
                TenantSelect obj = new TenantSelect();
                obj.Id = item.Id;
                obj.selected = tenantIds.Contains(item.Id);
                obj.TenantName = item.TenantName;
                TenantList.Add(obj);
            }
            result.Tenants = TenantList;

            CategoriesService CateServ = new CategoriesService();
            var Powers = CateServ.Reposity.GetAllList(o => o.Layout == "Powers");
            List<CategorySelect> PowerList = new List<CategorySelect>();
            foreach (var item in Powers)
            {
                CategorySelect obj = new CategorySelect();
                obj.Id = item.Id;
                obj.selected = powers.Contains(item.Id);
                obj.CategoryName = item.CategoryName;
                PowerList.Add(obj);
            }
            result.Powers = PowerList;

            AdminServ.Dispose();
            TenServ.Dispose();
            CateServ.Dispose();
            return Json(result);
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
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                using (AdminsService Admin = new AdminsService())
                {
                    if (input.Id == 0)
                    {
                        input.CreationTime = DateTime.Now;
                        input.Password = AppBase.MD5(input.Password);
                    }
                    Admin.Reposity.InsertOrUpdate(input);
                    result.code = 100;
                    result.datas = input.Id;
                    result.message = "ok";
                }
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult ResetPsw(int adminId, string oldPassword, string newPassword)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                using (AdminsService Admin = new AdminsService())
                {
                    var obj = Admin.Reposity.Get(adminId);
                    if (AppBase.MD5(oldPassword) != obj.Password)
                    {
                        result.code = 500;
                        result.message = "original password error";
                    }
                    else
                    {
                        obj.Password = AppBase.MD5(newPassword);
                        Admin.Reposity.Update(obj);
                        result.code = 100;
                        result.datas = obj.Id;
                        result.message = "ok";
                    }
                }
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
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

        public JsonResult GetPageLists(int page, int pageSize, string keywords = "")
        {
            throw new NotImplementedException();
        }
    }
}