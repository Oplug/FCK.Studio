using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 站点ID
        /// </summary>
        public int TenantId = AppBase.GetTenantId();
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int AdminId = AppBase.GetAdminId();

        public string GetRndCode(int length)
        {
            var result = new System.Text.StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                result.Append(r.Next(0, 10));
            }
            return result.ToString();
        }
        public string CellVal(IRow header, string CellName, IRow row)
        {
            string result = "";
            try
            {
                ICell cell = header.Cells.Where(o => o.StringCellValue == CellName).FirstOrDefault();
                if (cell != null)
                {
                    result = GetCellValue(row.Cells[cell.ColumnIndex]);
                }
            }
            catch { }
            return result;
        }
        public string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Numeric:
                case CellType.Unknown:
                default:
                    return cell.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Formula:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }
    }
}