/* ==============================================================================
 * 文件名称：使用TT模板生成数据库中所有表的业务逻辑类
 * 文件描述：
 * 创建人：jason
 * 创建时间：2013/10/17 20:40:59
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
  
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.IBLL
{

    public partial interface IAboutService : IBaseService<About>
    {

    }


    public partial interface IBannerService : IBaseService<Banner>
    {

    }


    public partial interface IBaseUserService : IBaseService<BaseUser>
    {

    }


    public partial interface INewsService : IBaseService<News>
    {

    }


    public partial interface IPCategoryService : IBaseService<PCategory>
    {

    }


    public partial interface IProductService : IBaseService<Product>
    {

    }


    public partial interface IRoleService : IBaseService<Role>
    {

    }


    public partial interface ISiteConfigService : IBaseService<SiteConfig>
    {

    }


    public partial interface ISystemMenuService : IBaseService<SystemMenu>
    {

    }


}