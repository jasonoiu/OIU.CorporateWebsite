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
  

using OIU.CorporateWebsite.IDAL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.DAL
{

    public partial class AboutRepository : BaseRepository<About>, IAboutRepository
    {

    }


    public partial class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {

    }


    public partial class BaseUserRepository : BaseRepository<BaseUser>, IBaseUserRepository
    {

    }


    public partial class NewsRepository : BaseRepository<News>, INewsRepository
    {

    }


    public partial class PCategoryRepository : BaseRepository<PCategory>, IPCategoryRepository
    {

    }


    public partial class ProductRepository : BaseRepository<Product>, IProductRepository
    {

    }


    public partial class RoleRepository : BaseRepository<Role>, IRoleRepository
    {

    }


    public partial class SiteConfigRepository : BaseRepository<SiteConfig>, ISiteConfigRepository
    {

    }


    public partial class SystemMenuRepository : BaseRepository<SystemMenu>, ISystemMenuRepository
    {

    }


}