using OnlineAuction.Logic.Domains;
using OnlineAuction.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Admin
{
    public partial class UsersMng : System.Web.UI.Page
    {
        protected AuctionEntities au = new AuctionEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack &&
            !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.RedirectToRoute("login");
                return;
            }

            if (Security.Authorizate(HttpContext.Current.User.Identity.Name) != Security.SystemRoles.Admin)
            {
                Response.RedirectToRoute("login");
                return;
            }

        }

        protected IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = new List<User>();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                users = au.Users.OrderBy(u => u.IdRole);
                return users;
            }
            return users;
        }

        public string CreateUrl(User user)
        {

                string path = RouteTable.Routes.GetVirtualPath(null, "edituser",
                    new RouteValueDictionary()
                {
                    {"edituser", user.Id}
                }).VirtualPath;


                return string.Format("<a href='{0}'>Изменить</a>",
                    path);

        }
    }
}