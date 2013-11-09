using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.IBLL
{
    public partial interface IBannerService : IBaseService<Banner>
    {
        /// <summary>
        /// 删除数据和图片文件
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        bool DeleteEntityAndImgFile(Banner m);
    }
}
