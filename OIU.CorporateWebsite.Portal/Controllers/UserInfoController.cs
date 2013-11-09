using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IBLL.IBaseUserService _userInfoService=new BaseUserService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUserInfo()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 1 : int.Parse(Request["rows"]);
            int total = 0;

            var data = _userInfoService.LoadPageEntities(pageIndex, pageSize, out total, u => true, true, u => u.ID);
            var result = new {total = total, rows = data};

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(BaseUser userInfo)
        {
            if (string.IsNullOrEmpty(userInfo.UserName) || string.IsNullOrEmpty(userInfo.PassWord))
            {
                return Content("用户名或密码不能为空！");
            }
            userInfo.Code = Guid.NewGuid().ToString();  //随机产生的一些数据
            userInfo.QuickQuery = userInfo.UserName;
            userInfo.UserFrom = "用户注册";

            _userInfoService.AddEntity(userInfo);
            return Content("OK");
        }

    }
}
