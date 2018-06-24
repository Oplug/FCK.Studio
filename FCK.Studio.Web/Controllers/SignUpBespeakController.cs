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
    public class SignUpBespeakController : BaseController, IControllerBase<SignUpBespeak, long>
    {
        public JsonResult Del(long id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SignUpBespeakService Serv = new SignUpBespeakService();
                Serv.Reposity.Delete(id);
                result.code = 100;
                result.message = "success";
                Serv.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult DelPatch(string[] ids)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                SignUpBespeakService Serv = new SignUpBespeakService();
                foreach(string id in ids)
                {
                    Serv.Reposity.Delete(int.Parse(id));
                }                
                result.code = 100;
                result.message = "success";
                Serv.Dispose();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            SignUpBespeakService Serv = new SignUpBespeakService();
            var result = Serv.Reposity.GetPageList(page, pageSize, (o => o.TenantId == TenantId));
            var lists = Mapper.Map<ResultDto<List<Dto.SignUpBespeakDto>>>(result);
            return Json(lists);
        }
        public JsonResult GetPageLists(int page, int pageSize, string keywords = "")
        {
            SignUpBespeakService Serv = new SignUpBespeakService();
            ResultDto<List<SignUpBespeak>> result = new ResultDto<List<SignUpBespeak>>();
            if (string.IsNullOrEmpty(keywords))
            {
                result = Serv.GetListOrderByTime(page, pageSize, (o => o.TenantId == TenantId));
            }
            else
                result = Serv.GetListOrderByTime(page, pageSize, (o => o.TenantId == TenantId && o.ActvTitle.Contains(keywords)));
            var lists = Mapper.Map<ResultDto<List<Dto.SignUpBespeakDto>>>(result);
            Serv.Dispose();
            return Json(lists);
        }

        public JsonResult GetModel(long id)
        {
            Dto.SignUpBespeakDto model = new Dto.SignUpBespeakDto();
            SignUpBespeakService Serv = new SignUpBespeakService();
            var result = Serv.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = Mapper.Map<Dto.SignUpBespeakDto>(result); ;
            }
            return Json(model);
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id=0)
        {
            ViewBag.Id = id;
            return View();
        }

        public JsonResult InsertOrUpdate(SignUpBespeak input)
        {
            throw new NotImplementedException();
        }
        
    }
}