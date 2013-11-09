/* ==============================================================================
 * 文件名称：使用TT模板生成数据库中所有表的工厂类
 * 文件描述：
 * 创建人：jason
 * 创建时间：2013/10/13 20:13:59
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
  
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.IDAL
{

    public partial interface IAboutRepository : IBaseRepository<About>
    {

    }


    public partial interface IBannerRepository : IBaseRepository<Banner>
    {

    }


    public partial interface IBaseUserRepository : IBaseRepository<BaseUser>
    {

    }


    public partial interface INewsRepository : IBaseRepository<News>
    {

    }


    public partial interface IPCategoryRepository : IBaseRepository<PCategory>
    {

    }


    public partial interface IProductRepository : IBaseRepository<Product>
    {

    }


    public partial interface IRoleRepository : IBaseRepository<Role>
    {

    }


    public partial interface ISiteConfigRepository : IBaseRepository<SiteConfig>
    {

    }


    public partial interface ISystemMenuRepository : IBaseRepository<SystemMenu>
    {

    }


}