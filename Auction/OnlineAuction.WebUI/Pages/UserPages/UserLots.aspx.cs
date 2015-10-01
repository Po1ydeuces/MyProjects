using OnlineAuction.Logic.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.UserPages
{
    public partial class UserLots : System.Web.UI.Page
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
        }

        protected IEnumerable<UserLot> GetUserLots()
        {
            IEnumerable<UserLot> userLots = new List<UserLot>();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                int userId = au.Users
                    .Where(u => u.Login
                                == HttpContext.Current.User.Identity.Name)
                    .Select(u => u.Id)
                    .First();
                
                userLots = au.UserLots.Where(ul => ul.IdUser == userId).OrderBy(ul => ul.idStatus);
                return userLots;
            }
            return userLots;
        }

        public string CreateUrl(UserLot userLot)
        {
            if (userLot.idStatus == 1)
            {

                string path = RouteTable.Routes.GetVirtualPath(null, "editlot",
                    new RouteValueDictionary()
                {
                    {"editlot", userLot.IdLot}
                }).VirtualPath;


                return string.Format("<a href='{0}'>Изменить</a>",
                    path);
            }
            return string.Format("<a href='' class='disabled'>Изменить</a>");;
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("addlot");
        }

    }
}