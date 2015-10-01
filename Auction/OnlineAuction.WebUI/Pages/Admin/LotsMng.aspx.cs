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
    public partial class LotsMng : System.Web.UI.Page
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

            if (Security.Authorizate(HttpContext.Current.User.Identity.Name) == Security.SystemRoles.User)
            {
                Response.RedirectToRoute("login");
                return;
            }
        }

        protected IEnumerable<Lot> GetLots()
        {
            IEnumerable<Lot> lots = new List<Lot>();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                lots = au.Lots.OrderByDescending(l => l.Status); 
                return lots;
            }
            return lots;
        }

        public string CreateUrl(Lot lot)
        {
            if (lot.Status == true)
            {

                string path = RouteTable.Routes.GetVirtualPath(null, "editlot",
                    new RouteValueDictionary()
                {
                    {"editlot", lot.IdLot}
                }).VirtualPath;


                return string.Format("<a href='{0}'>Изменить</a>",
                    path);
            }
            return string.Format("<a href='' class='disabled'>Изменить</a>"); ;
        }

    }
}