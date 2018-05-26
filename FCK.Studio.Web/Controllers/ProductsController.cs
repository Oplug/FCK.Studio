using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using AutoMapper;

namespace FCK.Studio.Web.Controllers
{
    public class ProductsController : BaseController, IControllerBase<Products, long>
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }

        public JsonResult GetModel(long id)
        {
            Products model = new Products();
            ProductsService Product = new ProductsService();
            var result = Product.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
            var entity = Mapper.Map<Dto.ProductDto>(model);
            Product.Dispose();
            return Json(entity);
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            ProductsService ObjServ = new ProductsService();
            var result = ObjServ.Reposity.GetPageList(page, pageSize, (o => o.TenantId == TenantId));
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Products input)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                using (ProductsService ObjServ = new ProductsService())
                {
                    if (input.Id == 0)
                    {
                        input.CreationTime = DateTime.Now;
                    }
                    input.TenantId = TenantId;
                    ObjServ.Reposity.InsertOrUpdate(input);
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

        public JsonResult Del(long id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                ProductsService ObjServ = new ProductsService();
                ObjServ.Reposity.Delete(id);
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
            ResultDto<List<Dto.ProductDto>> result = new ResultDto<List<Dto.ProductDto>>();
            try
            {
                ResultDto<List<Products>> items = new ResultDto<List<Products>>();
                ProductsService ObjServ = new ProductsService();
                if (!string.IsNullOrEmpty(keywords))
                {
                    items = ObjServ.Reposity.GetPageList(page, pageSize, o => (o.Title.Contains(keywords) && o.TenantId == TenantId));
                }
                else
                {
                    items = ObjServ.Reposity.GetPageList(page, pageSize, o => o.TenantId == TenantId);
                }
                result = Mapper.Map<ResultDto<List<Dto.ProductDto>>>(items);
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