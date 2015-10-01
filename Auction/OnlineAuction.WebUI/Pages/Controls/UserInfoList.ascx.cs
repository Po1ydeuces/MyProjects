using OnlineAuction.Logic.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Controls
{
    public partial class UserInfoList : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack &&
               !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.RedirectToRoute("login");
                return;
            }

            if (!Page.IsPostBack
                && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                using (AuctionEntities au = new AuctionEntities())
                {
                    User user = au.Users
                        .First(u => u.Login == HttpContext.Current.User.Identity.Name);

                    LoginInfo.Text = user.Login;
                    RoleInfo.Text = user.Role.NameRole;
                    NameInfo.Text = user.Name;
                    EmailInfo.Text = user.Email;
                    AddressInfo.Text = user.Address;
                    PhoneInfo.Text = user.Phone;

                    MyLotsInfo.Text = au.UserLots
                       .Count(ul => ul.IdUser == user.Id && ul.idStatus == 1).ToString();
                    SellLotsInfo.Text = au.UserLots
                        .Count(ul => ul.IdUser == user.Id && ul.idStatus == 4).ToString();
                    BuyLotsInfo.Text = au.UserLots
                        .Count(ul => ul.IdUser == user.Id && ul.idStatus == 5).ToString();
                }

            }

        }
    }
}