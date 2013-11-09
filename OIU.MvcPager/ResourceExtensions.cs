using System.Web.Mvc;
using System.Web.UI;

namespace OIU.MvcPager
{
    public static class ResourceExtensions
    {
        /// <summary>
        /// HtmlHelper扩展，注册MvcPager的客户端jQuery插件脚本
        /// </summary>
        /// <param name="html"></param>
        public static void RegisterMvcPagerScriptResource(this HtmlHelper html)
        {
            var page = html.ViewContext.HttpContext.CurrentHandler as Page;
            var scriptUrl = (page ?? new Page()).ClientScript.GetWebResourceUrl(typeof(PagerHelper), "OIU.MvcPager.MvcPager.js");
            html.ViewContext.Writer.Write("<script type=\"text/javascript\" src=\"" + scriptUrl + "\"></script>");
        }

        /// <summary>
        /// HtmlHelper扩展，引用MvcPager的客户端皮肤样式文件
        /// </summary>
        /// <param name="html"></param>
        public static void RegisterMvcPagerCssResource(this HtmlHelper html)
        {
            var page = html.ViewContext.HttpContext.CurrentHandler as Page;
            var cssUrl = (page ?? new Page()).ClientScript.GetWebResourceUrl(typeof(PagerHelper), "OIU.MvcPager.pagerstyles.css");
            html.ViewContext.Writer.Write("<link rel=\"stylesheet\" href=\"" + cssUrl + "\"></script>");
        }
    }
}