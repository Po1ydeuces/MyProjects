using OnlineAuction.Logic.Domains;
using OnlineAuction.Logic.Domains.Models;
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
    public partial class SectionMng : System.Web.UI.Page
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


            int sectionId;
            if (int.TryParse(Request.Form["remove"], out sectionId))
            {
                using (AuctionEntities au = new AuctionEntities())
                {
                    Section section = au.Sections
                        .First(s => s.Id == sectionId);

                    if (section != null && section.Id != 1)
                    {
                        au.Sections.Remove(section);
                        au.SaveChanges();

                    }
                }
            }


        }

        protected IEnumerable<Section> GetSections()
        {
            IEnumerable<Section> sections = new List<Section>();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                    sections = au.Sections
                        .OrderBy(s => s.NameSection)
                        .Where(s => s.Id != 1);
                    return sections;
            }
            return sections;
        }

        public string CreateUrl(Section section)
        {
                string path = RouteTable.Routes.GetVirtualPath(null, "editsection",
                    new RouteValueDictionary()
                {
                    {"editsection", section.Id}
                }).VirtualPath;


                return string.Format("<a href='{0}'>Изменить</a>",
                    path);

        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("addsection");
        }

    }
}