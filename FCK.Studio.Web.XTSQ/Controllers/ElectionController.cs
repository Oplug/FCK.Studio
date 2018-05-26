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
    public class ElectionController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetModel(int id = 0)
        {
            Core.Election model = new Core.Election();
            ElectionService ObjServ = new ElectionService();
            var result = ObjServ.Reposity.Get(id);
            if (result != null)
            {
                model = result;
            }
            ObjServ.Dispose();
            return Json(model);
        }
        public JsonResult GetLists(int page, int pageSize, string keywords = "")
        {
            ElectionService ObjServ = new ElectionService();
            var items = ObjServ.Reposity.GetPageList(page, pageSize, o => o.IsOpen && o.TenantId == tenant.Id);
            var result = Mapper.Map<ResultDto<List<Dto.ElectionDto>>>(items);
            if (result.datas != null)
                result.datas = result.datas.OrderByDescending(o => o.CreationTime).ToList();
            ObjServ.Dispose();
            return Json(result);
        }

        public JsonResult DoVote(int id)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                ElectionService ObjServ = new ElectionService();
                var entity = ObjServ.Reposity.Get(id);
                entity.Voter = entity.Voter == null ? "admin" : entity.Voter;
                if (MemberId <= 0)
                {
                    result.code = 500;
                    result.message = "请先登录再投票";
                }
                else if (!entity.IsOpen)
                {
                    result.code = 500;
                    result.message = "投票通道已经关闭";
                }
                else if (entity.EndTime < DateTime.Now)
                {
                    result.code = 500;
                    result.message = "选举已经过期";
                }
                else if (entity.Voter.Contains(Member.UserName))
                {
                    result.code = 500;
                    result.message = "您已经投票过了哦";
                }
                else
                {
                    entity.NumOfVote += 1;
                    entity.Voter += "," + Member.UserName;
                    ObjServ.Reposity.InsertOrUpdate(entity);
                    ObjServ.Dispose();
                    result.code = 100;
                    result.message = "ok";
                    result.datas = entity.Id;
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