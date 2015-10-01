﻿using OnlineAuction.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.RedirectToRoute("main");
        }

        protected void MainLinkBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("main");
        }

        protected void CatalogLinkBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("catalog");
        }

        protected void UserCabinetLinkBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("cabinet");
        }

        protected void LoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Response.RedirectToRoute("login");
        }
    }
}