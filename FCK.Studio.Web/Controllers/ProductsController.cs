using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;

namespace FCK.Studio.Web.Controllers
{
    public class ProductsController : BaseController, IControllerBase<Products, long>
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
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
            return Json(model);
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            ProductsService Product = new ProductsService();
            var result = Product.Reposity.GetPageList(page, pageSize, (o => o.TenantId == TenantId));
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Products input)
        {
            using (ProductsService Product = new ProductsService())
            {
                if (input.Id == 0)
                {
                    input.CreationTime = DateTime.Now;
                }
                input.Contents = HttpUtility.UrlDecode(input.Contents);
                input.TenantId = TenantId;
                var result = Product.Reposity.InsertOrUpdate(input);
                return Json(result);
            }
        }

        public JsonResult Del(long id)
        {
            Studio.Dto.ResultDto<string> result = new Studio.Dto.ResultDto<string>();
            try
            {
                ProductsService Product = new ProductsService();
                Product.Reposity.Delete(id);
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