using OnlineAuction.Logic.Domains;
using OnlineAuction.Logic.Domains.Models;
using OnlineAuction.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected User user;
        protected AuctionEntities au = new AuctionEntities();
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

                if (Security.Authorizate(HttpContext.Current.User.Identity.Name) != Security.SystemRoles.Admin)
                {
                    Response.RedirectToRoute("login");
                    return;
                }
                MultiView.ActiveViewIndex = 0;
                int userId;
                int.TryParse((string)Page.RouteData.Values["edituser"]
                                ?? Request.QueryString["edituser"], out userId);

                user = au.Users.First(u => u.Id == userId);
                loginBox.Text = user.Login;
                passBox.Text = user.Password;
                ddlRoles.SelectedIndex = user.IdRole - 1;
                nameBox.Text = user.Name;
                addressBox.Text = user.Address;
                phoneBox.Text = user.Phone;
                emailBox.Text = user.Email;

            }


        }

        protected void EmailCheckValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {

            args.IsValid = true;
        }


        protected void saveBtn_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                int userId;
                int.TryParse((string)Page.RouteData.Values["edituser"]
                                ?? Request.QueryString["edituser"], out userId);
                user = au.Users.First(u => u.Id == userId);

                user.Password = passBox.Text;
                user.Name = nameBox.Text;
                switch (ddlRoles.SelectedIndex)
                {

                    case 0: user.IdRole = 1; break;
                    case 1: user.IdRole = 2; break;
                    case 2: user.IdRole = 3; break;

                }
                user.Address = addressBox.Text;
                user.Phone = phoneBox.Text;
                user.Email = emailBox.Text;

                Methods.AddUser(user);
                MultiView.ActiveViewIndex = 1;

            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("usersmng");
        }
    }
}