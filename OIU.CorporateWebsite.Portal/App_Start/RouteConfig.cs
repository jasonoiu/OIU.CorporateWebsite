using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OIU.CorporateWebsite.Portal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "pager",
                url: "{controller}/page_{id}",
                defaults: new { controller = "News", action = "Index"},
                namespaces: new[] { "OIU.CorporateWebsite.Portal.Controllers" }
            );
            routes.MapRoute(
                name: "detailspager",
                url: "{controller}/details/{id}/page_{pageIndex}",
                defaults: new { controller = "product", action = "details" },
                namespaces: new[] { "OIU.CorporateWebsite.Portal.Controllers" }
            );
            routes.MapRoute(
                name: "pcategory",
                url: "product/c{cid}",
                defaults: new { controller = "product", action = "category" },
                namespaces: new[] { "OIU.CorporateWebsite.Portal.Controllers" }
            );
            routes.MapRoute(
                name: "pcategoryPage",
                url: "product/c{cid}/page_{pageIndex}",
                defaults: new { controller = "product", action = "category" },
                namespaces: new[] { "OIU.CorporateWebsite.Portal.Controllers" }
            );
            routes.MapRoute(
                name: "about",
                url: "about/{idname}",
                defaults: new { controller = "about", action = "Index" },
                constraints:new {idname=@"[\w]{3,50}"},
                namespaces: new[] { "OIU.CorporateWebsite.Portal.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OIU.CorporateWebsite.Portal.Controllers" }
            );





        }
    }
}