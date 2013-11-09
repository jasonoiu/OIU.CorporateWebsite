/* ==============================================================================
  * 类名称：BaseController
  * 类描述：控制器基类，判断用户是否登录
  * 创建人：jason
  * 创建时间：2013/10/15 19:44:30
  * 修改人：
  * 修改时间：
  * 修改备注：
  * @version 1.0
  * ==============================================================================*/

using System.Linq;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Common;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    /// <summary>
    /// 控制器基类，判断用户是否登录
    /// </summary>
    public class BaseController : Controller
    {
        private readonly IBLL.IBaseUserService _baseUserService = new BaseUserService();
        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public BaseUser CurrentUser 
        {
            get
            {
                if (Session["CurrentUser"] == null)
                {
                    var id =
                        CookiesHelper.Decrypt(
                            CookiesHelper.GetCurrentCookies(ProjectConst.CookiesClient, ProjectConst.CookiesClientID),
                            CookiesHelper.CookiesKey);
                    if (WebHelper.IsNumeric(id) == false) return null;
                    var uid = int.Parse(id);
                    Session["CurrentUser"] = _baseUserService.LoadEntities(u => u.ID == uid).FirstOrDefault();
                }
                return (BaseUser) Session["CurrentUser"];
            } 
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (CurrentUser == null)
            {
                Response.Redirect("/webadmin/Login");
            }
        }
    }
}