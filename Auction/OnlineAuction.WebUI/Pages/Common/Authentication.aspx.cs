using OnlineAuction.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Common
{
    public partial class Authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }


        protected void LoginControl_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            e.Authenticated = Security.Authenticate(LoginControl.UserName, LoginControl.Password);
        }

    }
}