using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.MvcPager;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBLL.IProductService _productService=new ProductService();
        private readonly IBLL.IPCategoryService _pCategoryService=new PCategoryService();

        public ActionResult Index(int id=1)
        {
            return View(_productService.LoadEntities(m => true).OrderByDescending(m => m.AddTime).ToPagedList(id, 10));
        }

        public ActionResult Category(int cid,int pageIndex=1)
        {
            var pc = _pCategoryService.LoadEntities(m => m.ID == cid).FirstOrDefault();
            if (pc == null)
            {
                RedirectToAction("Index");
            }
            ViewBag.pc = pc;
            return View(_productService.LoadEntities(m => m.PCid==cid).OrderByDescending(m => m.AddTime).ToPagedList(pageIndex, 10));
        }

        public ActionResult Details(int id, int pageIndex = 1)
        {
            var model = _productService.LoadEntities(m => m.ID == id).FirstOrDefault();
            if (model == null)
            {
                RedirectToAction("Index");
            }
            var pc = _pCategoryService.LoadEntities(m => m.ID == model.PCid).FirstOrDefault();
            if (pc == null)
            {
                RedirectToAction("Index");
            }
            var prelation = _productService.LoadEntities(m => (m.PCid == model.PCid && m.ID != model.ID)).OrderByDescending(m => m.AddTime).ToPagedList(pageIndex, 6);
            ViewBag.prelation = prelation;
            ViewBag.pc = pc;
            return View(model);
        }

    }
}
