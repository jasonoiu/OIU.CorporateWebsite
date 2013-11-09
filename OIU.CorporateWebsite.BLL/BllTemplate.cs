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
using OIU.CorporateWebsite.IBLL;

namespace OIU.CorporateWebsite.BLL
{

    public partial class AboutService : BaseService<About>, IAboutService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.AboutRepository;
        }
    }


    public partial class BannerService : BaseService<Banner>, IBannerService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.BannerRepository;
        }
    }


    public partial class BaseUserService : BaseService<BaseUser>, IBaseUserService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.BaseUserRepository;
        }
    }


    public partial class NewsService : BaseService<News>, INewsService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.NewsRepository;
        }
    }


    public partial class PCategoryService : BaseService<PCategory>, IPCategoryService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.PCategoryRepository;
        }
    }


    public partial class ProductService : BaseService<Product>, IProductService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.ProductRepository;
        }
    }


    public partial class RoleService : BaseService<Role>, IRoleService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.RoleRepository;
        }
    }


    public partial class SiteConfigService : BaseService<SiteConfig>, ISiteConfigService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.SiteConfigRepository;
        }
    }


    public partial class SystemMenuService : BaseService<SystemMenu>, ISystemMenuService
    {
		/// <summary>
        /// 设置当前工厂类
        /// </summary>
		public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.SystemMenuRepository;
        }
    }


}