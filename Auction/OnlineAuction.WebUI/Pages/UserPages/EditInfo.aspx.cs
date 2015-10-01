using OnlineAuction.Logic.Domains;
using OnlineAuction.Logic.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.UserPages
{
    public partial class EditInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack &&
              !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.RedirectToRoute("login");
                return;
            }
            if (!Page.IsPostBack &&
              HttpContext.Current.User.Identity.IsAuthenticated)
            {
                MultiView.ActiveViewIndex = 0;
                using (AuctionEntities au = new AuctionEntities())
                {
                    User user = au.Users
                       .First(u => u.Login == HttpContext.Current.User.Identity.Name);

                    nameBox.Text = user.Name;
                    addressBox.Text = user.Address;
                    phoneBox.Text = user.Phone;
                }
            }

        }

        protected void saveBtn_Click(object sender, EventArgs e)
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
                        user.Name = nameBox.Text;
                        user.Address = addressBox.Text;
                        user.Phone = phoneBox.Text;
                        Methods.AddUser(user);
                        MultiView.ActiveViewIndex = 1;

                    }
                }
            }
        }
    }
}