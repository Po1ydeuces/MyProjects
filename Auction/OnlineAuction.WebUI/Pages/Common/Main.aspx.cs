using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineAuction.Logic.Domains;
using System.Web.Routing;
using OnlineAuction.Logic.Domains.Models;
using System.Web.Services;
using OnlineAuction.WebUI.Models;


namespace OnlineAuction.WebUI.Pages.Common
{
    public partial class Main : System.Web.UI.Page
    {
        protected AuctionEntities au = new AuctionEntities();

        protected IEnumerable<Lot> GetActiveLots()
        {
            return au.Lots
                .Where(l => l.Status == true)
                .OrderBy(l => l.Name)
                .Take(au.Lots.Count());

        }

        protected IEnumerable<Lot> GetInactiveLots()
        {
            return au.Lots
                .Where(l => l.Status == false)
                .OrderBy(l => l.Name)
                .Take(au.Lots.Count());

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Methods.UpdateLotsStatus();
            }
            catch
            {
                Response.Redirect("notfound");
            }

        }

        [WebMethod]
        public static string RandomLotImg()
        {
            using (AuctionEntities au = new AuctionEntities())
            {
                int rnd = new Random().Next(au.Lots.Count());

                string imgTag = au.Lots
                    .OrderBy(l => l.IdLot)
                    .Skip(rnd)
                    .Select(l => l.Img)
                    .First();

                int lotId = au.Lots.Where(l => l.Img == imgTag)
                    .Select(l => l.IdLot)
                    .First();

                Lot lot = au.Lots.First(l => l.IdLot == lotId);

                string link = UrlCreater.CreateUrl(lot);
                string name = lot.Name;

                return imgTag + "*/*" + link + "*/*" + name;
            }

        }


   }
}