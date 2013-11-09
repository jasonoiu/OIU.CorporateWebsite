using System;
using System.Linq;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.MvcPager;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class NewsController : Controller
    {
        private readonly IBLL.INewsService _newsService = new NewsService();

        public ActionResult Index(int id = 1)
        {
            return View(_newsService.LoadEntities(m => true).OrderByDescending(m => m.AddTime).ToPagedList(id, 10));
        }


        public ActionResult Details(int id)
        {
            var model = _newsService.LoadEntities(m => m.ID == id).FirstOrDefault();
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
