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
    [Filters.FilterCheckLogin]
    public class MemberController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Id = MemberId;
            return View();
        }
        public ActionResult MyProfile()
        {
            return View();
        }

        public JsonResult GetModel()
        {
            Core.Members model = new Core.Members();
            MembersService ObjServ = new MembersService();
            var result = ObjServ.Reposity.Get(MemberId);
            if (result != null)
            {
                model = result;
            }
            else
            {
                model.TenantId = tenant.Id;
            }
            var entity = Mapper.Map<Dto.MemberDto>(model);
            ObjServ.Dispose();
            return Json(model);
        }

        public JsonResult GetList()
        {
            MembersService ObjServ = new MembersService();
            var result = ObjServ.Reposity.GetPageList(1, 8, o => o.TenantId == tenant.Id);
            result.datas = result.datas.OrderByDescending(o => o.CreationTime).ToList();
            ObjServ.Dispose();
            return Json(result);
        }
        public JsonResult Update(Core.Members input)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                MembersService ObjServ = new MembersService();
                MembersService ObjServRead = new MembersService();
                var item1 = ObjServ.Reposity.GetAllList(o => o.UserName == input.UserName && o.Id != MemberId).Count();
                var item2 = ObjServ.Reposity.GetAllList(o => o.Mobile == input.Mobile && o.Id != MemberId).Count();
                var item3 = ObjServ.Reposity.GetAllList(o => o.UserID == input.UserID && o.Id != MemberId).Count();
                if (item1 > 0)
                {
                    result.code = 500;
                    result.message = "用户名已经存在";
                }
                else if (item2 > 0)
                {
                    result.code = 500;
                    result.message = "手机号已经存在";
                }
                else if (item3 > 0)
                {
                    result.code = 500;
                    result.message = "身份证号已经存在";
                }
                else
                {
                    var model = ObjServRead.Reposity.Get(input.Id);
                    input.Password = model.Password;
                    input.CreationTime = model.CreationTime;
                    ObjServ.Reposity.Update(input);
                    result.code = 100;
                    result.message = "ok";
                }
                ObjServ.Dispose();
                ObjServRead.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetCreditRec(int memberid)
        {
            CreditRecordService ObjServ = new CreditRecordService();
            var result = ObjServ.Reposity.GetPageList(1, 20, o => o.TenantId == tenant.Id && o.MemberId==memberid);
            result.datas = result.datas.OrderByDescending(o => o.Id).ToList();
            ObjServ.Dispose();
            return Json(result);
        }
    }
}