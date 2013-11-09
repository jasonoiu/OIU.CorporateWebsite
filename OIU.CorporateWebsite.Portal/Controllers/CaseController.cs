using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class CaseController : Controller
    {
        private readonly IBLL.IBannerService _bannerService = new BannerService();

        public ActionResult Index()
        {
            return View(_bannerService.LoadEntities(m => m.ImgCategory == "工作现场"));
        }

    }
}
