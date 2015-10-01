using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineAuction.WebUI.Pages.Controls
{
    public partial class Search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string search = (string)Page.RouteData.Values["search"]
                                ?? Request.QueryString["search"];
                if (search != null)
                    FindBox.Text = search;
            }
        }

        protected void FindBtn_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(FindBox.Text))
            {
                string path = RouteTable.Routes.GetVirtualPath(null, "search",
                    new RouteValueDictionary()
                {                   
                    {"search", FindBox.Text},
                    {"page", "1"}
                }).VirtualPath;
                Response.Redirect(path);
            }

        }
    }
}