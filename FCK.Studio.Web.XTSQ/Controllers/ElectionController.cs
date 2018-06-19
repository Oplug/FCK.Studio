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

        public ActionResult Detail(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }

        public JsonResult GetModel(int id = 0)
        {
            Core.ElectionHead model = new Core.ElectionHead();
            ElectionService ObjServ = new ElectionService();
            var result = ObjServ.ReposityHD.Get(id);
            if (result != null)
            {
                model = result;
            }
            var entity = Mapper.Map<Dto.ElectionHdDto>(model);
            ObjServ.Dispose();
            return Json(entity);
        }
        public JsonResult GetLists(int page, int pageSize, int electionHdId)
        {
            ElectionService ObjServ = new ElectionService();
            var items = ObjServ.Reposity.GetPageList(page, pageSize, o => o.IsOpen && o.TenantId == tenant.Id && o.ElectionHdId == electionHdId);
            var result = Mapper.Map<ResultDto<List<Dto.ElectionDto>>>(items);
            if (result.datas != null)
                result.datas = result.datas.OrderByDescending(o => o.CreationTime).ToList();
            ObjServ.Dispose();
            return Json(result);
        }

        public JsonResult DoVote(string ids)
        {
            ResultDto<long> result = new ResultDto<long>();
            try
            {
                if (MemberId <= 0)
                {
                    result.code = 500;
                    result.message = "请先登录再投票";
                }
                else if (Member.UserID == "00")
                {
                    result.code = 500;
                    result.message = "对不起，您不是户籍人员，暂时不能投票";
                }
                else
                {
                    ElectionService ObjServ = new ElectionService();
                    string[] idarr = ids.Split(',');
                    foreach (string item in idarr)
                    {
                        int id = int.Parse(item);
                        var entity = ObjServ.Reposity.Get(id);
                        entity.Voter = entity.Voter == null ? "admin" : entity.Voter;
                        if (!entity.IsOpen)
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
                            result.code = 100;
                            result.message = "ok";
                            result.datas = entity.Id;
                        }
                    }
                    ObjServ.Dispose();
                }

            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetVoteItems(int page, int pageSize)
        {
            ResultDto<List<Dto.ElectionHdDto>> result = new ResultDto<List<Dto.ElectionHdDto>>();
            try
            {
                ElectionService ObjServ = new ElectionService();
                var items = ObjServ.ReposityHD.GetPageList(page, pageSize, o => o.TenantId == tenant.Id && o.EndTime > DateTime.Now && o.IsOpen);
                result = Mapper.Map<ResultDto<List<Dto.ElectionHdDto>>>(items);
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