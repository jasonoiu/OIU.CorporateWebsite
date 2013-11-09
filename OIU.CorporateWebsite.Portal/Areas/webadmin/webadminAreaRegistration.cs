using System.Web.Mvc;

namespace OIU.CorporateWebsite.Portal.Areas.webadmin
{
    public class webadminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "webadmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "webadmin_default",
                "webadmin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
