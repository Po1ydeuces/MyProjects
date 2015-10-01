using OnlineAuction.WebUI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using OnlineAuction.Logic.Domains;
using log4net;
using System.IO;

namespace OnlineAuction.WebUI
{
    public class Global : System.Web.HttpApplication

    {
        private static readonly ILog log = LogManager.GetLogger("Auction");
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
                Exception ex = Server.GetLastError();
                    log.Debug("++++++++++++++++++++++++++++");
                    log.Error("Exception - \n" + ex);
                    log.Debug("++++++++++++++++++++++++++++");
                Server.ClearError();

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}