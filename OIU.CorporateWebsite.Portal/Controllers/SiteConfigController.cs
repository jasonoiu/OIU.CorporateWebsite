using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class SiteConfigController : Controller
    {
        private readonly IBLL.ISiteConfigService _siteConfigService = new SiteConfigService();
        private readonly IBLL.IBannerService _bannerService = new BannerService();
        private readonly IBLL.IPCategoryService _pCategoryService = new PCategoryService();
        private readonly IBLL.IAboutService _aboutService = new AboutService();

        private SiteConfig getModel()
        {
            return _siteConfigService.LoadEntities(m => m.ID == 1).FirstOrDefault();
        }
        [OutputCache(Duration = 60)]
        public ActionResult Seo()
        {
            return PartialView("_PartialSeo", getModel());
        }
        [OutputCache(Duration = 60)]
        public ActionResult Logo()
        {
            return PartialView("_PartialLogo", getModel());
        }

        [OutputCache(Duration = 60)]
        public ActionResult Footer()
        {
            return Content(getModel().SiteFooter);
        }

        [OutputCache(Duration = 60)]
        public ActionResult Banner()
        {
            ViewBag.bannerList = _bannerService.LoadEntities(m => m.ImgCategory == "Banner");
            ViewBag.pcategoryList = _pCategoryService.LoadEntities(m => true);
            return PartialView("_PartialBanner");
        }

        [OutputCache(Duration = 60)]
        public ActionResult SiteLeft()
        {
            ViewBag.pcategoryList = _pCategoryService.LoadEntities(m => true);
            var info = _aboutService.LoadEntities(m => m.ID == 5).FirstOrDefault();
            return PartialView("_PartialLeft", info);
        }

    }
}
