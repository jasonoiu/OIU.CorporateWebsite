using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OIU.CorporateWebsite.IBLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.BLL
{
    public partial class BannerService : BaseService<Banner>, IBannerService
    {
        /// <summary>
        /// 删除数据和图片文件
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool DeleteEntityAndImgFile(Banner m)
        {
            //del product's img
            File.Delete(HttpContext.Current.Server.MapPath("~" + m.ImgUrl));

            return DeleteEntity(m);
        }
    }
}
