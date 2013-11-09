using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBLL.INewsService _newsService = new NewsService();
        private readonly IBLL.IProductService _productService = new ProductService();
        private readonly IBLL.IPCategoryService _pCategoryService = new PCategoryService();
        private readonly IBLL.IAboutService _aboutService = new AboutService();

        public ActionResult Index()
        {
            ViewBag.newsList = _newsService.LoadEntities(m => true).OrderByDescending(m => m.AddTime).Take(8);
            ViewBag.productList =
                _productService.LoadEntities(m => m.IsRecommend == true).OrderByDescending(m => m.AddTime).Take(8);
            return View(_aboutService.LoadEntities(m => m.ID == 4).FirstOrDefault());
        }

        
    }
}
