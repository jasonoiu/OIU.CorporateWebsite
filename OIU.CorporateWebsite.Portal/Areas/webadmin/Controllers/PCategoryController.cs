using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class PCategoryController : BaseController
    {
        private readonly IBLL.IPCategoryService _pCategoryService = new PCategoryService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            var temp =_pCategoryService.LoadEntities(m=>true);
            var total = 0;
            total = temp.Count();
            var data = temp.OrderBy(u => u.ID).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            //构造成Json的格式传递
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(PCategory info)
        {
            if (info == null)
            {
                return Content("错误信息，请您检查");
            }
            info.Pid = 0;
            _pCategoryService.AddEntity(info);
            return Content("ok");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(PCategory info)
        {
            var pCategory = _pCategoryService.LoadEntities(m => m.ID == info.ID).FirstOrDefault();
            if (pCategory == null)
            {
                return Content("错误信息，请您检查");
            }
            _pCategoryService.DeleteEntity(pCategory);
            return Content("ok");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(PCategory info)
        {
            _pCategoryService.UpdateEntity(info);
            return Content("ok");
        }

    }
}
