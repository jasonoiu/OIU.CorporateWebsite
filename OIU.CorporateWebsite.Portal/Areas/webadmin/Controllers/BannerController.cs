using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBLL.IBannerService _bannerService = new BannerService();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetInfo(int id)
        {
            var bannerInfo = _bannerService.LoadEntities(m => m.ID == id).FirstOrDefault();
            return Json(bannerInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            var imgCategory = Request["ImgCategory"];

            var temp = _bannerService.LoadEntities(m => true);
            if (!string.IsNullOrEmpty(imgCategory))
            {
                temp = temp.Where<Banner>(u => u.ImgCategory == imgCategory);
            }
            var total = 0;
            total = temp.Count();
            var data = temp.OrderBy(u => u.ID).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            //构造成Json的格式传递
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Banner info)
        {
            if (info == null || string.IsNullOrEmpty(info.ImgCategory) || string.IsNullOrEmpty(info.ImgUrl))
            {
                return Content("错误信息，请您检查");
            }
            _bannerService.AddEntity(info);
            return Content("ok");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(Banner info)
        {
            var pCategory = _bannerService.LoadEntities(m => m.ID == info.ID).FirstOrDefault();
            if (pCategory == null)
            {
                return Content("错误信息，请您检查");
            }
            _bannerService.DeleteEntityAndImgFile(pCategory);

            return Content("ok");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Banner info)
        {
            if (info == null || string.IsNullOrEmpty(info.ImgCategory) || string.IsNullOrEmpty(info.ImgUrl))
            {
                return Content("错误信息，请您检查");
            }
            _bannerService.UpdateEntity(info);
            return Content("ok");
        }

    }
}
