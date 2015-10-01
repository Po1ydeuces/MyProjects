using OnlineAuction.Logic.Domains;
using OnlineAuction.Logic.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Common
{
    public partial class Registration : System.Web.UI.Page
    {
        private const int roleId = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                RegMultiView.ActiveViewIndex = 0;
        }

        protected void RegButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                using (AuctionEntities au = new AuctionEntities())
                {

                    User user = new User();
                    user.Login = loginBox.Text;
                    user.Password = passBox.Text;
                    user.Email = emailBox.Text;
                    user.IdRole = roleId;
                    Methods.AddUser(user);
                    RegMultiView.ActiveViewIndex = 1;
                }
            }
        }

        protected void EmailCheckValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (AuctionEntities au = new AuctionEntities())
            {
                args.IsValid = !(au.Users
                   .Any(u => u.Email == emailBox.Text));
            }
        }

        protected void UserExistValidator_ServerValidate(object source,
            ServerValidateEventArgs args)
        {
            using (AuctionEntities au = new AuctionEntities())
            {
                args.IsValid = !(au.Users
                    .Any(u => u.Login == loginBox.Text));
            }
        }         

    }
}