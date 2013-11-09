/* ==============================================================================
 * 文件名称：RepositoryFactory
 * 文件描述：使用TT模板生成数据库中所有表的库工厂
 * 创建人：jason
 * 创建时间：2013/10/17 20:40:59
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
  
using OIU.CorporateWebsite.IDAL;

namespace OIU.CorporateWebsite.DAL
{
	public static class RepositoryFactory
	{
	
		public static IAboutRepository AboutRepository
		{
			get{return new AboutRepository();}
		}

	 
		public static IBannerRepository BannerRepository
		{
			get{return new BannerRepository();}
		}

	 
		public static IBaseUserRepository BaseUserRepository
		{
			get{return new BaseUserRepository();}
		}

	 
		public static INewsRepository NewsRepository
		{
			get{return new NewsRepository();}
		}

	 
		public static IPCategoryRepository PCategoryRepository
		{
			get{return new PCategoryRepository();}
		}

	 
		public static IProductRepository ProductRepository
		{
			get{return new ProductRepository();}
		}

	 
		public static IRoleRepository RoleRepository
		{
			get{return new RoleRepository();}
		}

	 
		public static ISiteConfigRepository SiteConfigRepository
		{
			get{return new SiteConfigRepository();}
		}

	 
		public static ISystemMenuRepository SystemMenuRepository
		{
			get{return new SystemMenuRepository();}
		}

	 	}

}