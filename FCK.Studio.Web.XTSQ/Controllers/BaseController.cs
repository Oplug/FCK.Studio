using FCK.Studio.Application;
using FCK.Studio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Controllers
{
    public class BaseController : Controller
    {
        public string AppSecretKey = "ca56f1ac-2f12-4884-ab53-49af1dfbaab5";
        public Tenants tenant;
        private string DESKey = "123456";
        public int MemberId = 0;
        public Members Member;
        public BaseController()
        {
            tenant = new Tenants();
            try {
                TenantsService tenantS = new TenantsService();
                tenant = tenantS.Reposity.GetAllList(o => o.SecretKey == new Guid(AppSecretKey)).FirstOrDefault();                
                tenantS.Dispose();
                GetMemberCookie();
            } catch { } 
        }
        public void GetMemberCookie()
        {
            if (GetCookie("MemberId") != null && MemberId == 0)
            {
                MemberId = int.Parse(CookieVal("MemberId"));
                MembersService MembS = new MembersService();
                Member = MembS.Reposity.Get(MemberId);
            }
            else
                Member = new Members();
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5(string value)
        {
            byte[] result = Encoding.UTF8.GetBytes(value);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        /// <summary> 
        /// DES加密 
        /// </summary>
        public string DESEncrypt(string value, string _deskey = null)
        {
            if (string.IsNullOrEmpty(_deskey))
            {
                _deskey = DESKey;
            }

            byte[] keyArray = Encoding.UTF8.GetBytes(_deskey);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(value);

            DESCryptoServiceProvider rDel = new DESCryptoServiceProvider();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary> 
        /// DES解密 
        /// </summary>
        public string DESDecrypt(string value, string _deskey = null)
        {
            try
            {
                if (string.IsNullOrEmpty(_deskey))
                {
                    _deskey = DESKey;
                }
                byte[] keyArray = Encoding.UTF8.GetBytes(_deskey);
                byte[] toEncryptArray = Convert.FromBase64String(value);

                DESCryptoServiceProvider rDel = new DESCryptoServiceProvider();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool SetCookie(string strName, string strValue, int days)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Expires = DateTime.Now.AddDays(days);
                Cookie.Value = strValue;
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public HttpCookie GetCookie(string strName)
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
        public string CookieVal(string strName)
        {
            try
            {
                HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies[strName];
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
        public bool DelCookie(string strName, string domain)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                Cookie.Values.Clear();
                Cookie.Domain = domain;
                Cookie.Expires = DateTime.Now.AddDays(-1000);
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}