using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IBLL.IAboutService _aboutService=new AboutService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return Json(_aboutService.LoadEntities(m => true), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAboutInfo(int id)
        {
            var aboutInfo = _aboutService.LoadEntities(m => m.ID == id).FirstOrDefault();
            return Json(aboutInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(About info)
        {
            var aboutInfo = _aboutService.LoadEntities(m => m.ID == info.ID).FirstOrDefault();
            if (aboutInfo == null)
            {
                return Content("错误信息，请您检查");
            }

            aboutInfo.Contents = info.Contents;
            _aboutService.UpdateEntity(aboutInfo);
            return Content("ok");
        }
    }
}
