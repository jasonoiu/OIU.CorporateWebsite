using System;
using System.Web;
using System.Web.Mvc;

namespace OIU.CorporateWebsite.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new AppHandleErrorAttribute());
        }

        /// <summary>
        /// 错误日志（Controller发生异常时会执行这里）
        /// </summary>
        public class AppHandleErrorAttribute : HandleErrorAttribute
        {
            /// <summary>
            /// 异常
            /// </summary>
            /// <param name="filterContext"></param>
            public override void OnException(ExceptionContext filterContext)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectResult("~/error");//跳转至错误提示页面
            }
        }
    }
}