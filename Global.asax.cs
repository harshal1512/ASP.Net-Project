using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Asp.net
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //application insist hello monee
            Application.Add("name","hello monee"); //key value format
        }

        void Session_Start(object sender,EventArgs e)
        {
            Session.Add("userid","");
        }

        void Session_End(object sender, EventArgs e)
        {
            Session.Clear();
        }
    }
}