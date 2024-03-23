using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            IList<PMSBillList> PMSBL = new List<PMSBillList>();
            Session["billdata"] = PMSBL;
            Session["billdate"] = "";
            Session["seller"] = 1;
            Session["billamount"] = 0;
        }


    }
}
