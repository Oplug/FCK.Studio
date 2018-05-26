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
    public class DemdInfoController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult SubInfo()
        {
            return View();
        }
        public ActionResult SubService()
        {
            return View();
        }

        public JsonResult GetModel(long id = 0)
        {
            Core.DemdInfo model = new Core.DemdInfo();
            DemdInfoService ObjServ = new DemdInfoService();
            var result = ObjServ.Reposity.Get(id);
            if (result != null)
            {
                model = result;
            }
            var entity = Mapper.Map<Dto.DemdInfoDto>(model);
            ObjServ.Dispose();
            return Json(entity);
        }
        [Filters.FilterCheckLogin]
        public JsonResult InsertOrUpdate(Core.DemdInfo input)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                DemdInfoService ObjServ = new DemdInfoService();
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
            DemdInfoService ObjServ = new DemdInfoService();
            var items = ObjServ.Reposity.GetPageList(page, pageSize, o => o.IsChecked && o.TenantId == tenant.Id);
            var result = Mapper.Map<ResultDto<List<Dto.DemdInfoDto>>>(items);
            if (result.datas != null)
                result.datas = result.datas.OrderByDescending(o => o.CreationTime).ToList();
            ObjServ.Dispose();
            return Json(result);
        }

        [Filters.FilterCheckLogin]
        public JsonResult Remark(string contents, string objs,long id)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                Core.Comments input = new Core.Comments();
                CommentsService ObjServ = new CommentsService();
                input.ModelId = id;
                input.TenantId = tenant.Id;
                input.MemberId = MemberId;
                input.CreationTime = DateTime.Now;
                input.Contents = contents;
                input.ModelName = objs;
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

        public JsonResult GetComments(int page, int pageSize, long id, string objs = "")
        {
            CommentsService ObjServ = new CommentsService();
            var items = ObjServ.Reposity.GetPageList(page, pageSize, o => o.TenantId == tenant.Id && o.ModelName == objs && o.ModelId == id);
            var result = Mapper.Map<ResultDto<List<Dto.CommentDto>>>(items);
            if (result.datas != null)
                result.datas = result.datas.OrderByDescending(o => o.CreationTime).ToList();
            ObjServ.Dispose();
            return Json(result);
        }
    }
}