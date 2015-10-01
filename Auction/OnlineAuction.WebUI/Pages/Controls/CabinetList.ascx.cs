using OnlineAuction.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Controls
{
    public partial class CabinetList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            editLots.Visible = false;
            editUsers.Visible = false;
            editSections.Visible = false;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                switch (Security.Authorizate(HttpContext.Current.User.Identity.Name))
                {
                    case Security.SystemRoles.Admin:
                        {
                            editLots.Visible = true;
                            editSections.Visible = true;
                            editUsers.Visible = true;
                        }

                        break;

                    case Security.SystemRoles.Manager:
                        editLots.Visible = true;
                        editSections.Visible = true;
                        break;

                }
            }

        }

        protected void userInfo_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("cabinet");
        }

        protected void editInfo_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("editinfo");
        }

        protected void editPass_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("editpassword");
        }

        protected void userLots_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("userlots");
        }

        protected void editLots_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("lotsmng");
        }

        protected void editUsers_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("usersmng");
        }

        protected void editSections_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("sectionmng");
        }
    }
}