using AutoMapper;
using FCK.Studio.Application;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class DemdInfoController : BaseController, IControllerBase<DemdInfo, long>
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
        public JsonResult Del(long id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                DemdInfoService ObjServ = new DemdInfoService();
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

        public JsonResult GetLists(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetModel(long id)
        {
            DemdInfo model = new DemdInfo();
            DemdInfoService ObjServ = new DemdInfoService();
            var result = ObjServ.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
            var entity = Mapper.Map<Dto.DemdInfoDto>(model);
            ObjServ.Dispose();
            return Json(entity);
        }

        public JsonResult GetPageLists(int page, int pageSize, string keywords = "")
        {
            ResultDto<List<Dto.DemdInfoDto>> result = new ResultDto<List<Dto.DemdInfoDto>>();
            try
            {
                ResultDto<List<DemdInfo>> items = new ResultDto<List<DemdInfo>>();
                DemdInfoService ObjServ = new DemdInfoService();
                if (!string.IsNullOrEmpty(keywords))
                {
                    items = ObjServ.Reposity.GetPageList(page, pageSize, o => (o.Title.Contains(keywords) && o.TenantId == TenantId));
                }
                else
                {
                    items = ObjServ.Reposity.GetPageList(page, pageSize, o => o.TenantId == TenantId);
                }
                result = Mapper.Map<ResultDto<List<Dto.DemdInfoDto>>>(items);
                ObjServ.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult InsertOrUpdate(DemdInfo input)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                using (DemdInfoService ObjServ = new DemdInfoService())
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

        public JsonResult Checked(long id)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                using (DemdInfoService ObjServ = new DemdInfoService())
                {
                    var input = ObjServ.Reposity.FirstOrDefault(id);
                    input.IsChecked = input.IsChecked ? false : true;
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
    }
}