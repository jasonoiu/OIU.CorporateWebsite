using System.Linq;
using System.Web.Mvc;
using OIU.CorporateWebsite.BLL;

namespace OIU.CorporateWebsite.Portal.Controllers
{
    public class SharedController : Controller
    {
        private readonly IBLL.ISiteConfigService _siteConfigService = new SiteConfigService();
        private readonly IBLL.IPCategoryService _pCategoryService = new PCategoryService();


        //

    }
}
