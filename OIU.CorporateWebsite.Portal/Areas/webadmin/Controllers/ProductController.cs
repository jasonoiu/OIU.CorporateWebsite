using System;
using System.Linq;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IBLL.IProductService _productService = new ProductService();
        private readonly IBLL.IPCategoryService _pCategoryService = new PCategoryService();
        public ActionResult Index()
        {
            ViewBag.PCategoryList = _pCategoryService.LoadEntities(m => m.Pid == 0);
            return View();
        }
        /// <summary>
        /// 根据ID获得产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetProductInfo(int id)
        {
            var productInfo = _productService.LoadEntities(m => m.ID == id).FirstOrDefault();
            return Json(productInfo, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetAllProduct()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            string PName = Request["PName"];
            var PCid = 0;
            int.TryParse(Request["PCid"], out PCid);

            int total = 0;

            var temp = _productService.LoadEntities(m => true);
            if (!string.IsNullOrEmpty(PName))
            {
                temp = temp.Where<Product>(u => u.PName.Contains(PName));
            }
            if (PCid != 0)
            {
                temp = temp.Where<Product>(u => u.PCid == PCid);
            }
            //var t = _productService.LoadEntities(m => true).Select(m => new
            //{
            //    m.ID,
            //    m.PCid,
            //    m.PContent,
            //    m.PImg,
            //    m.PName,
            //    CategoryName = _pCategoryService.LoadEntities(c => c.ID == m.PCid).FirstOrDefault().CName
            //}).ToList();
            total = temp.Count();
            var data = temp.OrderBy(u => u.ID).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            //构造成Json的格式传递
            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateProductInfo(Product info)
        {
            var productInfo = _productService.LoadEntities(m => m.ID == info.ID).FirstOrDefault();
            if (productInfo == null)
            {
                return Content("错误信息，请您检查");
            }

            productInfo.PCid = info.PCid;
            productInfo.PContent = info.PContent;
            productInfo.PImg = info.PImg;
            productInfo.PName = info.PName;
            productInfo.IsRecommend = info.IsRecommend;

            _productService.UpdateEntity(productInfo);
            return Content("ok");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProduct(Product info)
        {
            if (info == null)
            {
                return Content("错误信息，请您检查");
            }
            info.AddTime = DateTime.Now;
            _productService.AddEntity(info);
            return Content("ok");
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product info)
        {
            var productInfo = _productService.LoadEntities(m => m.ID == info.ID).FirstOrDefault();
            if (productInfo == null)
            {
                return Content("错误信息，请您检查");
            }
            _productService.DeleteProduct(productInfo);
            return Content("ok");

        }


    }
}
