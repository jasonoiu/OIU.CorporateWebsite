using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Common;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class BaseUserController : BaseController
    {
        private readonly IBLL.IBaseUserService _baseUserService = new BaseUserService();

        public ActionResult Updatepwd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Updatepwd(string pwd, string newpwd, string confirmnewpwd)
        {
            if (pwd == newpwd)
            {
                return Content("原密码与新密码不能相同！");
            }
            if (newpwd.Length < 6 || newpwd.Length > 12)
            {
                return Content("密码长度必须介于6和12之间！");
            }
            if (WebHelper.GetMd5Password(pwd) != CurrentUser.PassWord)
            {
                return Content("原密码错误！");
            }
            if (newpwd != confirmnewpwd)
            {
                return Content("两次输入的新密码不一致！");
            }

            CurrentUser.PassWord = WebHelper.GetMd5Password(newpwd);
            _baseUserService.UpdateEntity(CurrentUser);

            return Content("ok");
        }

    }
}
