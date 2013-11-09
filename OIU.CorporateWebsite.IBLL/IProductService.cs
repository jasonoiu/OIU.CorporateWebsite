using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.IBLL
{
    public partial interface IProductService:IBaseService<Product>
    {
        /// <summary>
        /// 删除产品（先删除产品图片文件）
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        bool DeleteProduct(Product m);
    }
}
