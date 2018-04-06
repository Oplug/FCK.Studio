using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}