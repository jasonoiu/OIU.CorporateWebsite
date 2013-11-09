using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class NewsController : BaseController
    {
        private readonly IBLL.INewsService _newsService = new NewsService();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetNewsInfo(int id)
        {
            var newsInfo = _newsService.LoadEntities(m => m.ID == id).FirstOrDefault();
            return Json(newsInfo, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetAllNews()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            string newsTitle = Request["NewsTitle"];
            //var PCid = 0;
            //int.TryParse(Request["PCid"], out PCid);

            int total = 0;

            var temp = _newsService.LoadEntities(m => true);
            if (!string.IsNullOrEmpty(newsTitle))
            {
                temp = temp.Where<News>(u => u.NewsTitle.Contains(newsTitle));
            }
            //if (PCid != 0)
            //{
            //    temp = temp.Where<News>(u => u.PCid == PCid);
            //}

            total = temp.Count();
            var data = temp.OrderByDescending(u => u.AddTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            //构造成Json的格式传递
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateNewsInfo(News info)
        {
            var newsInfo = _newsService.LoadEntities(m => m.ID == info.ID).FirstOrDefault();
            if (newsInfo == null)
            {
                return Content("错误信息，请您检查");
            }
            info.AddTime = DateTime.Now;

            _newsService.UpdateEntity(info);
            return Content("ok");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNews(News info)
        {
            if (info == null)
            {
                return Content("错误信息，请您检查");
            }
            info.AddTime = DateTime.Now;
            _newsService.AddEntity(info);
            return Content("ok");
        }

        [HttpPost]
        public ActionResult DeleteNews(News info)
        {
            var newsInfo = _newsService.LoadEntities(m => m.ID == info.ID).FirstOrDefault();
            if (newsInfo == null)
            {
                return Content("错误信息，请您检查");
            }
            _newsService.DeleteEntity(newsInfo);
            return Content("ok");

        }


    }
}
