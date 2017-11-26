using DataAccess;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pickup.com
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Database.SetInitializer<DBContext>(new Seeder());
        }

        protected void Session_Start()
        {
            Session["BID"] = null;
            Session["SID"] = null;
            Session["AID"] = null;
            Session["MID"] = null;
            Session["CART"] = null;
        }
    }
}
