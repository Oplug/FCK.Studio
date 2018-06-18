using System;
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
using System.Linq.Expressions;

namespace FCK.Studio.Web.Controllers
{
    public class MembersController : BaseController, IControllerBase<Members, int>
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult HouseList()
        {
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }

        public JsonResult GetModel(int id)
        {
            Members model = new Members();
            MembersService Member = new MembersService();
            var result = Member.Reposity.FirstOrDefault(id);
            if (result != null)
            {
                model = result;
            }
            return Json(model);
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            MembersService Member = new MembersService();
            var result = Member.Reposity.GetPageList(page, pageSize, o => o.TenantId == TenantId);
            return Json(result);
        }

        public JsonResult InsertOrUpdate(Members input)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                using (MembersService Member = new MembersService())
                {
                    if (input.Id == 0)
                    {
                        input.CreationTime = DateTime.Now;
                    }
                    else
                    {
                        input.UpdateTime = DateTime.Now;
                    }
                    MembersService ObjRead = new MembersService();
                    var obj = ObjRead.Reposity.GetAllList(o => o.UserID == input.UserID && o.Id != input.Id).FirstOrDefault();
                    if (obj != null)
                    {
                        result.code = 500;
                        result.message = "身份证号已存在";
                    }
                    else
                    {
                        input.TenantId = TenantId;

                        BirthdayAgeSex user = AppBase.GetBirthdayAgeSex(input.UserID);
                        if (user != null)
                        {
                            input.Age = user.Age;
                            input.Birthday = user.Birthday;
                            input.Sex = user.Sex;
                        }

                        Member.Reposity.InsertOrUpdate(input);
                        result.code = 100;
                        result.datas = input.Id;
                        result.message = "ok";
                    }
                    ObjRead.Dispose();
                }
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult InsertBlank()
        {
            ResultDto<int> result = new ResultDto<int>();
            try {                
                using (MembersService Member = new MembersService())
                {
                    Members obj = new Members();
                    obj.UserName = GetRndCode(6);
                    obj.Password = "96E79218965EB72C92A549DD5A330112";
                    obj.Email = "0";
                    obj.UserID = "0";                    
                    obj.TenantId = TenantId;
                    obj.CreationTime = DateTime.Now;
                    Member.Reposity.Insert(obj);
                    result.code = 100;
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

        public JsonResult Del(int id)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                MembersService Member = new MembersService();
                Member.Reposity.Delete(id);
                result.code = 100;
                result.message = "success";
                Member.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }

        public JsonResult DelPatch(string ids)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                MembersService Member = new MembersService();
                string[] idarr = ids.Split(',');
                foreach (string val in idarr)
                {
                    int id = Convert.ToInt32(val);
                    Member.Reposity.Delete(id);
                }
                result.code = 100;
                result.message = "success";
                Member.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }
        private ResultDto<List<Dto.MemberOutDto>> GetDatas(int page = 1, int pageSize = 0, string keywords = "")
        {
            ResultDto<List<Dto.MemberOutDto>> result = new ResultDto<List<Dto.MemberOutDto>>();
            try
            {
                ResultDto<List<Members>> items = new ResultDto<List<Members>>();
                MembersService Member = new MembersService();
                var predicate = PredicateBuilder.True<Members>();
                predicate = o => o.TenantId == TenantId;
                items = Member.GetListOrderByTime(page, pageSize, predicate, keywords);
                result = Mapper.Map<ResultDto<List<Dto.MemberOutDto>>>(items);
                Member.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return result;
        }

        public JsonResult GetPageListToEasyUI(int page, int rows, string keywords = "")
        {            
            var resp = GetDatas(page, rows, keywords);
            int total = resp.total;
            var data = new
            {
                total, 
                rows = resp.datas
            };
            return Json(data);
        }


        public JsonResult GetPageLists(int page, int pageSize, string keywords = "")
        {
            return Json(GetDatas(page, pageSize, keywords));
        }

        public FileResult GetCSV(int page, int pageSize, string keywords = "")
        {
            MemoryStream output = new MemoryStream();
            StreamWriter sw = new StreamWriter(output, Encoding.UTF8);
            var result = GetDatas(page, pageSize, keywords);
            foreach (var item in result.datas)
            {
                sw.Write(item.Relations + ",");
                sw.Write(item.TrueName + ",");
                sw.Write(item.Sex + ",");
                sw.Write(item.Nation + ",");
                sw.Write(item.Age + ",");
                sw.Write(item.UserID + ",");
                sw.Write(item.Address + ",");
                sw.Write(item.ServiceAddr + ",");
                sw.Write(item.Duties + ",");
                sw.Write(item.Phone + ",");
                sw.Write(item.PoliticalRole + ",");
                sw.Write(item.ResidentLeader + ",");
                sw.Write(item.Speciality);
                sw.WriteLine();
            }
            sw.Flush();
            output.Position = 0;
            return File(output, "text/comma-separated-values", "myscv.csv");
        }

        public JsonResult Approve(int id)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                using (MembersService ObjServ = new MembersService())
                {
                    var input = ObjServ.Reposity.FirstOrDefault(id);
                    input.Approved = input.Approved ? false : true;
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

        public ActionResult ImportData()
        {
            return View();
        }
        public ActionResult ImportHouse()
        {
            return View();
        }

        public JsonResult ImportExcel(HttpPostedFileBase file)
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
                    string[] CellArr = ("姓名|关系|民族|身份证号|楼盘|单元|门牌号|现户籍地址|原户籍地址|服务处所|职务|联系电话1|联系电话2|政治面貌|党员所在支部|特长备注").Split('|');
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
                        MembersService ObjServ = new MembersService();
                        for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row != null)
                            {

                                Members entity = new Members();
                                entity.TrueName = CellVal(headerRow, "姓名", row);
                                entity.Relations = CellVal(headerRow, "关系", row);
                                entity.Nation = CellVal(headerRow, "民族", row);
                                entity.UserID = CellVal(headerRow, "身份证号", row);
                                entity.Apartment = CellVal(headerRow, "楼盘", row);
                                entity.UnitNum = CellVal(headerRow, "单元", row);
                                entity.DoorCard = CellVal(headerRow, "门牌号", row);
                                entity.Address = CellVal(headerRow, "现户籍地址", row);
                                entity.Address2 = CellVal(headerRow, "原户籍地址", row);
                                entity.ServiceAddr = CellVal(headerRow, "服务处所", row);
                                entity.Duties = CellVal(headerRow, "职务", row);
                                entity.Phone = CellVal(headerRow, "联系电话1", row);
                                entity.Phone2 = CellVal(headerRow, "联系电话2", row);
                                entity.PoliticalRole = CellVal(headerRow, "政治面貌", row);
                                entity.PartyBranch = CellVal(headerRow, "党员所在支部", row);
                                entity.Speciality = CellVal(headerRow, "特长备注", row);
                                entity.HhdRegister = entity.Address.Contains(entity.Apartment);
                                entity.UserName = GetRndCode(6);
                                entity.Password = "96E79218965EB72C92A549DD5A330112";
                                entity.Email = "-";
                                entity.CreationTime = DateTime.Now;
                                entity.TenantId = TenantId;
                                BirthdayAgeSex user = AppBase.GetBirthdayAgeSex(entity.UserID);
                                if (user == null)
                                {
                                    entity.UserID = "身份证不合法";
                                }
                                else
                                {
                                    entity.Age = user.Age;
                                    entity.Birthday = user.Birthday;
                                    entity.Sex = user.Sex;
                                }

                                ObjServ.Reposity.Insert(entity);
                            }
                        }
                        result.code = 100;
                        result.message = "上传成功";
                        ObjServ.Dispose();
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
            MembersService ShipServ = new MembersService();

            var DataLists = ShipServ.Reposity.GetAllList();


            IRow rowhead = sheet1.CreateRow(0);
            string[] colums = ("编号|姓名|关系|性别|民族|出生年月|年龄|楼盘|单元|门牌号|身份证号|现户籍地址|原户籍地址|是否兴塘社区户籍|服务处处所|职务|联系方式|政治面貌|党支部|是否楼道组长|是否户代表|是否居民代表|是否居民组长|是否愿意参加公益|是否愿意从事居民事务|调查时间|专长/备注").Split('|');
            for (int i = 0; i < colums.Length; i++)
            {
                rowhead.CreateCell(i).SetCellValue(colums[i]);
            }

            int RowNum = 0;
            foreach (var item in DataLists)
            {
                IRow row = sheet1.CreateRow(RowNum + 1);
                row.CreateCell(0).SetCellValue(RowNum + 1);
                row.CreateCell(1).SetCellValue(item.TrueName);
                row.CreateCell(2).SetCellValue(item.Relations);
                row.CreateCell(3).SetCellValue(item.Sex);
                row.CreateCell(4).SetCellValue(item.Nation);
                row.CreateCell(5).SetCellValue(item.Birthday);
                row.CreateCell(6).SetCellValue(item.Age);
                row.CreateCell(7).SetCellValue(item.Apartment);
                row.CreateCell(8).SetCellValue(item.UnitNum);
                row.CreateCell(9).SetCellValue(item.DoorCard);
                row.CreateCell(10).SetCellValue(item.UserID);
                row.CreateCell(11).SetCellValue(item.Address);
                row.CreateCell(12).SetCellValue(item.Address2);
                row.CreateCell(13).SetCellValue(item.HhdRegister);
                row.CreateCell(14).SetCellValue(item.ServiceAddr);
                row.CreateCell(15).SetCellValue(item.Duties);
                row.CreateCell(16).SetCellValue(item.Phone + " " + item.Phone2);
                row.CreateCell(17).SetCellValue(item.PoliticalRole);
                row.CreateCell(18).SetCellValue(item.PartyBranch);
                row.CreateCell(19).SetCellValue(item.CorridorLeader);
                row.CreateCell(20).SetCellValue(item.HouseLeader);
                row.CreateCell(21).SetCellValue(item.ResidentRepresentative);
                row.CreateCell(22).SetCellValue(item.ResidentLeader);
                row.CreateCell(23).SetCellValue(item.Pipwa);
                row.CreateCell(24).SetCellValue(item.Eira);
                row.CreateCell(25).SetCellValue(item.CreationTime.ToString());
                row.CreateCell(26).SetCellValue(item.Speciality);
                RowNum++;
            }

            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ShipServ.Dispose();
            return File(ms, "application/vnd.ms-excel", "Members" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
        }


    }
}