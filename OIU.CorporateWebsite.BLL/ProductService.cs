using System.IO;
using System.Web;
using OIU.CorporateWebsite.IBLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.BLL
{
    public partial class ProductService : BaseService<Product>, IProductService
    {
        /// <summary>
        /// 删除产品（先删除产品图片文件）
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool DeleteProduct(Product m)
        {
            //del product's img
            File.Delete(HttpContext.Current.Server.MapPath("~"+m.PImg));

            return DeleteEntity(m);
        }
    }
}
