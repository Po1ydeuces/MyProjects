using OnlineAuction.Logic.Domains;
using OnlineAuction.Logic.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Controls
{
    public partial class PswValid : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack &&
              !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.RedirectToRoute("login");
                return;
            }

            if (!Page.IsPostBack)
                ChangePswView.ActiveViewIndex = 0;
        }

        protected void PswValidator_ServerValidate(object source,
        ServerValidateEventArgs args)
        {
            using (AuctionEntities au = new AuctionEntities())
            {
                args.IsValid = (au.Users
                    .Count(u => u.Login
                       == HttpContext.Current.User.Identity.Name &&
                       u.Password == oldPswBox.Text) == 1);
            }
        }

        protected void PswSaveBtn_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                using (AuctionEntities au = new AuctionEntities())
                {
                    User user = au.Users
                    .First(u => u.Login
                         == HttpContext.Current.User.Identity.Name);

                    if (user != null)
                    {
                        user.Password = newPswBox.Text;
                        Methods.AddUser(user);
                        ChangePswView.ActiveViewIndex = 1;
                    }
                }
            }
        }
    }
}