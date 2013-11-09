using System.Linq;
using OIU.CorporateWebsite.Common;
using OIU.CorporateWebsite.IBLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.BLL
{
    /// <summary>
    /// UserInfo业务逻辑
    /// </summary>
    public partial class BaseUserService : BaseService<BaseUser>, IBaseUserService
    {
        /// <summary>
        /// 检查用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public LoginResult CheckUserInfo(BaseUser userInfo)
        {
            //首先判断用户名，密码是否为空
            if (string.IsNullOrEmpty(userInfo.UserName))
            {
                return LoginResult.UserNameIsNull;
            }
            if (string.IsNullOrEmpty(userInfo.PassWord))
            {
                return LoginResult.PassWordIsNUll;
            }

            var loginUserInfoCheck = LoadEntities(u => u.UserName == userInfo.UserName).FirstOrDefault();
            if (loginUserInfoCheck == null)
            {
                return LoginResult.UserNotExist;
            }
            if (loginUserInfoCheck.PassWord != WebHelper.GetMd5Password(userInfo.PassWord))
            {
                return LoginResult.PassWordError;
            }
            else
            {
                userInfo.ID = loginUserInfoCheck.ID;
                return LoginResult.Success;
            }
        }
    }
}
