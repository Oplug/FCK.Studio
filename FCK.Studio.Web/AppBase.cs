using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FCK.Studio.Web
{
    public class AppBase
    {
        public static bool SetCookie(string strName, string strValue, int days)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.AddDays(days);
                Cookie.Value = strValue;
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static HttpCookie GetCookie(string strName)
        {
            HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies[strName];
            if (Cookie != null)
            {
                return Cookie;
            }
            else
            {
                return null;
            }
        }
        public static string CookieVal(string strName)
        {
            try
            {
                HttpCookie Cookie = HttpContext.Current.Request.Cookies[strName];
                if (Cookie != null)
                {
                    return Cookie.Value;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        public static bool DelCookie(string strName, string domain)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Values.Clear();
                Cookie.Domain = domain;
                Cookie.Expires = DateTime.Now.AddDays(-1000);
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取站点ID
        /// </summary>
        /// <returns></returns>
        public static int GetTenantId()
        {
            if (GetCookie("TenantId") != null)
            {
                return int.Parse(CookieVal("TenantId"));
            }
            else
                return 0;
        }

        public static int GetAdminId()
        {
            if (GetCookie("AdminId") != null)
            {
                return int.Parse(CookieVal("AdminId"));
            }
            else
                return 0;
        }

        public static BirthdayAgeSex GetBirthdayAgeSex(string identityCard)
        {
            if (string.IsNullOrEmpty(identityCard))
            {
                return null;
            }
            else
            {
                if (identityCard.Length != 15 && identityCard.Length != 18)//身份证号码只能为15位或18位其它不合法
                {
                    return null;
                }
            }

            BirthdayAgeSex entity = new BirthdayAgeSex();
            string strSex = string.Empty;
            if (identityCard.Length == 18)//处理18位的身份证号码从号码中得到生日和性别代码
            {
                entity.Birthday = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
                strSex = identityCard.Substring(14, 3);
            }
            if (identityCard.Length == 15)
            {
                entity.Birthday = "19" + identityCard.Substring(6, 2) + "-" + identityCard.Substring(8, 2) + "-" + identityCard.Substring(10, 2);
                strSex = identityCard.Substring(12, 3);
            }

            entity.Age = CalculateAge(entity.Birthday);
            if (int.Parse(strSex) % 2 == 0)
            {
                entity.Sex = "女";
            }
            else
            {
                entity.Sex = "男";
            }
            return entity;
        }
        /// <summary>
        /// 根据出生日期，计算精确的年龄
        /// </summary>
        /// <param name="birthDate">生日</param>
        /// <returns></returns>
        public static int CalculateAge(string birthDay)
        {
            DateTime birthDate = DateTime.Parse(birthDay);
            DateTime nowDateTime = DateTime.Now;
            int age = nowDateTime.Year - birthDate.Year;
            if (nowDateTime.Month < birthDate.Month || (nowDateTime.Month == birthDate.Month && nowDateTime.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }

        public Bitmap CreateQRCode(string strCode)
        {
            QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(strCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrcode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrcode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Jpeg);
            return qrCodeImage;
        }

        public static int Cint(object val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch { return 0; }
        }

        public static string MD5(string value)
        {
            byte[] result = Encoding.UTF8.GetBytes(value);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
    }

    public class BirthdayAgeSex
    {
        public string Birthday { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }


}