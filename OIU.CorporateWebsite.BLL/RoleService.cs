/* ==============================================================================
 * 类名称：RoleService
 * 类描述：
 * 创建人：jason
 * 创建时间：2013/10/13 18:50:08
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using OIU.CorporateWebsite.IBLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.BLL
{
    /// <summary>
    /// Role业务逻辑类
    /// </summary>
    public class RoleService:BaseService<Role>,IRoleService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.RoleRepository;
        }
    }
}
