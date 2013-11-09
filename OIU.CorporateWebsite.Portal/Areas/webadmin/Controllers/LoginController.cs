using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;
using OIU.CorporateWebsite.Common;
using OIU.CorporateWebsite.Model;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin.Controllers
{
    public class LoginController : Controller
    {
        //实例化UserInfo接口的对象
        private readonly IBLL.IBaseUserService _baseUserService = new BaseUserService();

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获得验证码图片文件
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            //首先实例化验证码的类
            var validateCode = new KenceryValidateCode();
            //生成验证码指定的长度
            string code = validateCode.CreateValidateCode(4);
            this.TempData["ValidateCode"] = code;
            //创建验证码的图片
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        [HttpPost]
        public ActionResult CheckUserInfo(BaseUser userInfo, string code)
        {
            //var sessionCode = this.TempData["ValidateCode"] == null
            //    ? new Guid().ToString()
            //    : this.TempData["ValidateCode"].ToString();
            ////将验证码去掉，避免暴力破解
            //this.TempData["ValidateCode"] = new Guid();

            ////判断用户输入的验证码是否正确
            //if (sessionCode != code)
            //{
            //    return Content("验证码输入不正确");
            //}
            //调用业务逻辑层（BLL）去校验用户是否正确
            var loginUserInfo = _baseUserService.CheckUserInfo(userInfo);
            if (loginUserInfo == LoginResult.Success)
            {
                string enStr = CookiesHelper.Encrypt(userInfo.ID.ToString(), CookiesHelper.CookiesKey);
                CookiesHelper.SaveCookies(ProjectConst.CookiesClient, ProjectConst.CookiesClientID, enStr, DateTime.Now.AddHours(12));
            }
            //获得错误信息（枚举的Description）
            var userInfoError = EnumManager<LoginResult>.GetDescriptionByName(loginUserInfo);
            return Content(userInfoError);
        }


        public ActionResult LogOut()
        {
            CookiesHelper.DelCookies(ProjectConst.CookiesClient);
            Session["CurrentUser"] = null;
            return RedirectToAction("Index");
        }


    }
}
