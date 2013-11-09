using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            ViewBag.ErrorString = "非常遗憾，程序出现未知错误，请与系统管理员联系！";
            return View();
        }

        public ActionResult NotFound()
        {
            ViewBag.ErrorString = "404错误,该页面不存在！";
            return View("Index");
        }

    }
}
