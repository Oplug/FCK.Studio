﻿using System;
using FCK.Studio.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using AutoMapper;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Text;

namespace FCK.Studio.Web.Controllers
{
    public class HousesController : BaseController, IControllerBase<Houses, int>
    {

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult MemberHouse(string id)
        {
            List<Dto.HouseDto> datas = new List<Dto.HouseDto>();
            using (HouseService ObjServ = new HouseService())
            {
                var items = ObjServ.Reposity.GetAllList(o => (o.Owner == id || o.Owner2 == id || o.Owner3 == id || o.Owner4 == id || o.Owner5 == id) && o.TenantId == TenantId);
                datas = Mapper.Map<List<Dto.HouseDto>>(items);
            }
            return View(datas);
        }
        public ActionResult HouseMembers(string id)
        {
            List<Dto.MemberOutDto> datas = new List<Dto.MemberOutDto>();
            using (MembersService ObjServ = new MembersService())
            {
                string[] info = id.Split('|');
                string apname = "";
                int unitNum = 0;
                int doorCard = 0;
                if (info.Count() == 3)
                {
                    apname = info[0];
                    unitNum = AppBase.Cint(info[1]);
                    doorCard = AppBase.Cint(info[2]);
                }
                var items = ObjServ.Reposity.GetAllList(o => o.Apartment == apname && o.UnitNum == unitNum && o.DoorCard == doorCard && o.TenantId == TenantId);
                datas = Mapper.Map<List<Dto.MemberOutDto>>(items);
            }
            return View(datas);
        }

        public JsonResult Del(int id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                HouseService ObjServ = new HouseService();
                ObjServ.Reposity.Delete(id);
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

        public JsonResult DelPatch(string[] ids)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                HouseService ObjServ = new HouseService();
                foreach (string val in ids)
                {
                    int id = Convert.ToInt32(val);
                    ObjServ.Reposity.Delete(id);
                }
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
            Houses model = new Houses();
            HouseService ObjServ = new HouseService();
            var result = ObjServ.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
            return Json(model);
        }
        private ResultDto<List<Dto.HouseDto>> GetDatas(int page = 1, int pageSize = 0, string keywords = "")
        {
            ResultDto<List<Dto.HouseDto>> result = new ResultDto<List<Dto.HouseDto>>();
            try
            {
                ResultDto<List<Houses>> items = new ResultDto<List<Houses>>();
                HouseService Member = new HouseService();
                //items = Member.GetListOrderByID(page, pageSize, o => o.TenantId == TenantId, keywords);
                items = Member.GetListSQL(page, pageSize, TenantId, keywords);
                result = Mapper.Map<ResultDto<List<Dto.HouseDto>>>(items);
                Member.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return result;
        }
        public JsonResult GetPageLists(int page, int pageSize, string keywords = "")
        {
            return Json(GetDatas(page, pageSize, keywords));
        }

        // GET: Houses
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertOrUpdate(Houses input)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                using (HouseService ObjServ = new HouseService())
                {
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
        public JsonResult ImportExcel(HttpPostedFileBase file, int cateid)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                if (file == null)
                {
                    result.code = 101;
                    result.message = "请选择上传的Excel文件";
                }
                else
                {
                    Stream inputStream = file.InputStream;
                    HSSFWorkbook hssfworkbook = new HSSFWorkbook(inputStream);
                    ISheet sheet = hssfworkbook.GetSheetAt(0);
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    int rowCount = sheet.LastRowNum;
                    string[] CellArr = ("楼盘名称|单元号|门牌号|房屋属性|房屋面积|销售状态|已建未建|产权所有人1|产权所有人2|产权所有人3|产权所有人4|产权所有人5|网格名称|网格员|备注").Split('|');
                    bool isValid = true;
                    foreach (string item in CellArr)
                    {
                        ICell cell = headerRow.Cells.Where(o => o.StringCellValue == item).FirstOrDefault();
                        if (cell == null)
                        {
                            result.code = 500;
                            result.message = "导入出错，缺少必要字段 “" + item + "”！";
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        string failRow = "#";
                        int okRow = 0;
                        HouseService ObjServ = new HouseService();
                        HouseService ObjServRead = new HouseService();
                        for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row != null)
                            {
                                try
                                {
                                    string houseName = CellVal(headerRow, "楼盘名称", row);
                                    int unitNum = AppBase.Cint(CellVal(headerRow, "单元号", row));
                                    int doorCard = AppBase.Cint(CellVal(headerRow, "门牌号", row));
                                    var obj = ObjServRead.Reposity.GetAllList(o => o.HouseName == houseName && o.UnitNum == unitNum && o.DoorCard == doorCard).FirstOrDefault();
                                    if (obj != null)
                                    {
                                        obj.HouseType = CellVal(headerRow, "房屋属性", row);
                                        obj.HouseArea = CellVal(headerRow, "房屋面积", row);
                                        obj.SaleStatus = CellVal(headerRow, "销售状态", row);
                                        obj.BuildStatus = CellVal(headerRow, "已建未建", row);
                                        obj.Owner = CellVal(headerRow, "产权所有人1", row);
                                        obj.Owner2 = CellVal(headerRow, "产权所有人2", row);
                                        obj.Owner3 = CellVal(headerRow, "产权所有人3", row);
                                        obj.Owner4 = CellVal(headerRow, "产权所有人4", row);
                                        obj.Owner5 = CellVal(headerRow, "产权所有人5", row);
                                        obj.ShortChar1 = CellVal(headerRow, "网格名称", row);
                                        obj.ShortChar2 = CellVal(headerRow, "网格员", row);
                                        obj.Memo = CellVal(headerRow, "备注", row);
                                        obj.TenantId = TenantId;
                                        obj.CategoryId = cateid;
                                        ObjServ.Reposity.Update(obj);
                                    }
                                    else
                                    {
                                        Houses entity = new Houses();
                                        entity.HouseName = CellVal(headerRow, "楼盘名称", row);
                                        entity.UnitNum = AppBase.Cint(CellVal(headerRow, "单元号", row));
                                        entity.DoorCard = AppBase.Cint(CellVal(headerRow, "门牌号", row));
                                        entity.HouseType = CellVal(headerRow, "房屋属性", row);
                                        entity.HouseArea = CellVal(headerRow, "房屋面积", row);
                                        entity.SaleStatus = CellVal(headerRow, "销售状态", row);
                                        entity.BuildStatus = CellVal(headerRow, "已建未建", row);
                                        entity.Owner = CellVal(headerRow, "产权所有人1", row);
                                        entity.Owner2 = CellVal(headerRow, "产权所有人2", row);
                                        entity.Owner3 = CellVal(headerRow, "产权所有人3", row);
                                        entity.Owner4 = CellVal(headerRow, "产权所有人4", row);
                                        entity.Owner5 = CellVal(headerRow, "产权所有人5", row);
                                        entity.ShortChar1 = CellVal(headerRow, "网格名称", row);
                                        entity.ShortChar2 = CellVal(headerRow, "网格员", row);
                                        entity.Memo = CellVal(headerRow, "备注", row);
                                        entity.TenantId = TenantId;
                                        entity.CategoryId = cateid;
                                        ObjServ.Reposity.Insert(entity);
                                    }
                                    okRow++;
                                }
                                catch (Exception ex) { failRow += "," + i + "行：" + ex.Message; continue; }
                            }
                        }
                        result.code = 100;
                        result.message = okRow + "行导入成功！";
                        ObjServ.Dispose();
                        ObjServRead.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                result.code = 101;
                result.message = "导入失败，错误原因：" + ex.Message;
            }
            return Json(result);
        }
        public FileResult ExportExcel(string keywords = "")
        {
            HSSFWorkbook book = new HSSFWorkbook();
            ISheet sheet1 = book.CreateSheet("Sheet1");
            HouseService ShipServ = new HouseService();

            var DataLists = ShipServ.Reposity.GetAllList();


            IRow rowhead = sheet1.CreateRow(0);
            string[] colums = ("楼盘名称|单元号|门牌号|房屋属性|房屋面积|销售状态|已建未建|产权所有人1|产权所有人2|产权所有人3|产权所有人4|产权所有人5|网格名称|网格员|备注").Split('|');
            for (int i = 0; i < colums.Length; i++)
            {
                rowhead.CreateCell(i).SetCellValue(colums[i]);
            }

            int RowNum = 0;
            foreach (var item in DataLists)
            {
                IRow row = sheet1.CreateRow(RowNum + 1);
                row.CreateCell(0).SetCellValue(item.HouseName);
                row.CreateCell(1).SetCellValue(item.UnitNum);
                row.CreateCell(2).SetCellValue(item.DoorCard);
                row.CreateCell(3).SetCellValue(item.HouseType);
                row.CreateCell(4).SetCellValue(item.HouseArea);
                row.CreateCell(5).SetCellValue(item.SaleStatus);
                row.CreateCell(6).SetCellValue(item.BuildStatus);
                row.CreateCell(7).SetCellValue(item.Owner);
                row.CreateCell(8).SetCellValue(item.Owner2);
                row.CreateCell(9).SetCellValue(item.Owner3);
                row.CreateCell(10).SetCellValue(item.Owner4);
                row.CreateCell(11).SetCellValue(item.Owner5);
                row.CreateCell(12).SetCellValue(item.ShortChar1);
                row.CreateCell(13).SetCellValue(item.ShortChar2);
                row.CreateCell(14).SetCellValue(item.Memo);
                RowNum++;
            }

            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ShipServ.Dispose();
            return File(ms, "application/vnd.ms-excel", "Houses" + DateTime.Now.ToString("mmss") + ".xls");
        }
    }
}