using OnlineAuction.Logic.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineAuction.WebUI.Pages.Controls;
using OnlineAuction.WebUI.Models;
using System.Web.Services;

namespace OnlineAuction.WebUI.Pages.Control
{
    public partial class SectionList : System.Web.UI.UserControl
    {
        AuctionEntities au = new AuctionEntities();

        protected IEnumerable<Section> GetSection()
        {
            return au.Sections
                 .OrderBy(s =>s.NameSection);
        }

     
        protected void AllLinkBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("catalog");
        }


        public string CreateUrl(string section)
        {
            string selectedSection = (string)Page.RouteData.Values["section"]
                ?? Request.QueryString["section"];


            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary()
                {
                    {"section", section},
                    {"page", "1"}
                }).VirtualPath;


            return string.Format("<a href='{0}' {1}>{2}</a>",
                path, section == selectedSection ? "class='selected'" : "", section);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }



    }
}