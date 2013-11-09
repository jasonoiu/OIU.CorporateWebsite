/* ==============================================================================
 * 类名称：IBaseUserService
 * 类描述：用户业务接口
 * 创建人：jason
 * 创建时间：2013/10/13 19:01:10
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using OIU.CorporateWebsite.Common;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.IBLL
{
    /// <summary>
    /// 用户业务接口
    /// </summary>
    public partial interface IBaseUserService : IBaseService<BaseUser>
    {
        //检查用户信息
        LoginResult CheckUserInfo(BaseUser userInfo);
    }
}
