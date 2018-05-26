using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FilterCheckLogin: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //检查登录是否过期
            if (HttpContext.Current.Request.Cookies["MemberId"] == null)
            {
                string loginUrl = "/Home/Login";
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }

        }
    }
}