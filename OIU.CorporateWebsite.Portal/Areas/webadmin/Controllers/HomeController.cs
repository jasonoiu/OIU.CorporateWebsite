using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Common;
using OIU.CorporateWebsite.IBLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISystemMenuService _systemMenu = new SystemMenuService();

        public ActionResult Index()
        {
            ViewBag.MenuList = _systemMenu.LoadEntities(m => m.IsDisable == false || m.IsDisable == null);

            return View(CurrentUser);
        }

    }
}
