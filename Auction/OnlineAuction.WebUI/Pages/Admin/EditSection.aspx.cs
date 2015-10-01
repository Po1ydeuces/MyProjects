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
    public partial class EditSection : System.Web.UI.Page
    {
        protected Section section;

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

                if (Security.Authorizate(HttpContext.Current.User.Identity.Name) == Security.SystemRoles.User)
                {
                    Response.RedirectToRoute("login");
                    return;
                }
                MultiView.ActiveViewIndex = 0;
                int sectionId;
                int.TryParse((string)Page.RouteData.Values["editsection"]
                                ?? Request.QueryString["editsection"], out sectionId);

                if (sectionId == 1)
                {
                    Response.RedirectToRoute("sectionmng");
                    return;
                }
                else
                {
                    if (sectionId != 0)
                    {
                        using (AuctionEntities au = new AuctionEntities())
                        {
                            section = au.Sections.First(s => s.Id == sectionId);
                            nameBox.Text = section.NameSection;
                        }
                    }
                }
            }


        }

        protected void nameCheckValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {

            using (AuctionEntities au = new AuctionEntities())
            {
                args.IsValid = !(au.Sections
                   .Any(s => s.NameSection == nameBox.Text));
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("sectionmng");
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                int sectionId;
                int.TryParse((string)Page.RouteData.Values["editsection"]
                                ?? Request.QueryString["editsection"], out sectionId);
                if (sectionId != 0)
                {
                    using (AuctionEntities au = new AuctionEntities())
                    {
                        section = au.Sections.First(s => s.Id == sectionId);
                        section.NameSection = nameBox.Text;
                        Methods.AddSection(section);
                        MultiView.ActiveViewIndex = 1;
                    }
                }
                else
                {
                    using (AuctionEntities au = new AuctionEntities())
                    {
                        Section newSection = new Section();
                        newSection.NameSection = nameBox.Text;
                        Methods.AddSection(newSection);
                        MultiView.ActiveViewIndex = 1;
                    }
                }
            }
        }
    }
}