using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class AboutController : Controller
    {
        private readonly IBLL.IAboutService _aboutService = new AboutService();

        public ActionResult Index(string idname)
        {
            var model = _aboutService.LoadEntities(m => m.IdName == idname).FirstOrDefault();
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}
