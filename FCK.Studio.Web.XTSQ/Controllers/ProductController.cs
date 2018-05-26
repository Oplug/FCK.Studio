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
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            ViewBag.Id = id;
            return View();
        }
        public JsonResult GetModel(long id = 0)
        {
            Core.Products model = new Core.Products();
            ProductsService ObjServ = new ProductsService();
            var result = ObjServ.Reposity.Get(id);
            if (result != null)
            {
                model = result;
            }
            var entity = Mapper.Map<Dto.ProductDto>(model);
            ObjServ.Dispose();
            return Json(entity);
        }
        [Filters.FilterCheckLogin]
        public JsonResult InsertOrUpdate(Core.Products input)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                ProductsService ObjServ = new ProductsService();
                input.TenantId = tenant.Id;
                input.CreatorUserId = MemberId;
                input.CreationTime = DateTime.Now;
                ObjServ.Reposity.InsertOrUpdate(input);
                ObjServ.Dispose();
                result.code = 100;
                result.message = "ok";
                result.datas = input.Id;
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetLists(int page, int pageSize, string keywords = "")
        {
            ProductsService ObjServ = new ProductsService();
            var items = ObjServ.Reposity.GetPageList(page, pageSize, o => o.TenantId == tenant.Id);
            var result = Mapper.Map<ResultDto<List<Dto.ProductDto>>>(items);
            if (result.datas != null)
                result.datas = result.datas.OrderByDescending(o => o.CreationTime).ToList();
            ObjServ.Dispose();
            return Json(result);
        }
    }
}