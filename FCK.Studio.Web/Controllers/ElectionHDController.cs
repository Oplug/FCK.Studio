﻿using AutoMapper;
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
    public class ElectionHDController : BaseController, IControllerBase<ElectionHead, int>
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
        public JsonResult Del(int id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                ElectionService ObjServ = new ElectionService();
                ObjServ.ReposityHD.Delete(id);
                result.code = 100;
                result.message = "success";
                ObjServ.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetModel(int id)
        {
            ElectionHead model = new ElectionHead();
            ElectionService ObjServ = new ElectionService();
            var result = ObjServ.ReposityHD.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
            var entity = Mapper.Map<Dto.ElectionHdDto>(model);
            ObjServ.Dispose();
            return Json(entity);
        }

        public JsonResult GetPageLists(int page, int pageSize, string keywords = "")
        {
            ResultDto<List<Dto.ElectionHdDto>> result = new ResultDto<List<Dto.ElectionHdDto>>();
            try
            {
                ResultDto<List<ElectionHead>> items = new ResultDto<List<ElectionHead>>();
                ElectionService ObjServ = new ElectionService();
                if (!string.IsNullOrEmpty(keywords))
                {
                    items = ObjServ.ReposityHD.GetPageList(page, pageSize, o => (o.Title.Contains(keywords) && o.TenantId == TenantId));
                }
                else
                {
                    items = ObjServ.ReposityHD.GetPageList(page, pageSize, o => o.TenantId == TenantId);
                }
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

        public JsonResult InsertOrUpdate(ElectionHead input)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                using (ElectionService ObjServ = new ElectionService())
                {
                    if (input.Id == 0)
                    {
                        input.CreationTime = DateTime.Now;
                    }
                    input.TenantId = TenantId;
                    ObjServ.ReposityHD.InsertOrUpdate(input);
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
        public JsonResult DoOpen(int id)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                using (ElectionService ObjServ = new ElectionService())
                {
                    var input = ObjServ.ReposityHD.FirstOrDefault(id);
                    input.IsOpen = input.IsOpen ? false : true;
                    ObjServ.ReposityHD.InsertOrUpdate(input);
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