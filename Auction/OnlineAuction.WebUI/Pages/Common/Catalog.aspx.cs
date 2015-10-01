using OnlineAuction.Logic.Domains;
using OnlineAuction.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Common
{
    public partial class Catalog : System.Web.UI.Page
    {

        private int pageSize = 8;

        protected AuctionEntities au = new AuctionEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected int GetCurrentPage(int page)
        {
            if (page <= 0)
                return 1;

            return page > MaxPage
                ? MaxPage
                : page;
        }
        protected int RequestPage
        {
            get { return GetPageFromRequest(); }
            set { }
        }

        private int GetPageFromRequest()
        {
            int page;
            string request = (string)Page.RouteData.Values["page"]
                ?? Request.QueryString["page"];
            return request != null
                && int.TryParse(request, out page)
                ? page
                : 1;
        }

        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling(
                    (decimal)(FilterLots().
                    Count()) / pageSize);
            }
        }

        protected IEnumerable<Lot> GetLots()
        {
            return FilterLots()
                .Skip((GetCurrentPage(RequestPage) - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Lot> FilterLots()
        {
            IEnumerable<Lot> lots = au.Lots;

            string search = (string)Page.RouteData.Values["search"]
                ?? Request.QueryString["search"];

            if (!string.IsNullOrEmpty(search))
                lots = lots.
                    Where(b => b.Name.ToLower()
                        .Contains(search.ToLower()));

            else 
            {
                string section = (string)Page.RouteData.Values["section"]
                    ?? Request.QueryString["section"];


                if (!string.IsNullOrEmpty(section))
                {
                    lots = lots
                        .Where(l => l.Section.NameSection == section)
                        .Take(pageSize);
                }

            }

            return lots;
        }


       

    }
}