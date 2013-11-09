using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class SiteConfigController : BaseController
    {
        private readonly IBLL.ISiteConfigService _siteConfigService = new SiteConfigService();

        public ActionResult Index()
        {
            var info = _siteConfigService.LoadEntities(m => m.ID == 1).FirstOrDefault() ?? addDefaultData();
            //ViewBag.Info = info;
            return View(info);
        }

        SiteConfig addDefaultData()
        {
            var info = new SiteConfig { ID = 1, SeoTitle = "网站标题" };
            _siteConfigService.AddEntity(info);
            return info;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(SiteConfig info)
        {
            _siteConfigService.UpdateEntity(info);
            return Content("ok");
        }

    }
}
