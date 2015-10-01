<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Catalog.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Common.Catalog" %>

<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="OnlineAuction.Logic.Domains" %>
<%@ Import Namespace="OnlineAuction.WebUI.Models" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCatalog" runat="server">

    <div id="ctlgmap"></div>
    <div class="mainsection">

        <%
            if (GetLots().Any())
            {
                foreach (Lot lots in GetLots())
                {
                    var date = lots.EndDate - DateTime.Now;
                    string dt = string.Format("{0}дн. {1}ч.", date.Days, date.Hours);
                    if (lots.EndDate <= DateTime.Now)
                    {
                        dt = "Завершены";
                    }
                    Response.Write(String.Format(@"
                    <div id='ctlgitem' class='item'>
                    <div class='blockimg'>
                    <img src='{0}' alt='Img'><br>
                    </div>
                    <a href='{1}'>{2}</a><br/><br/>
                    <h4>Окончание торгов:</h4><br/>{3}<br/><br/>
                    <h4>Текущая цена:</h4><br/>{4:c}
                    </div>",
                    String.Format("/DataBase/Images/{0}", lots.Img),
                    UrlCreater.CreateUrl(lots), lots.Name,
                    dt, lots.CurrentPrice));
                }
            }
            else Response.RedirectToRoute("notfound");

        %>
    </div>

    <div id="ctlglisting">
        <%
            if (GetLots().Any())
            {
                for (int i = 1; i <= MaxPage; i++)
                {
                    string selectedSection = (string)Page.RouteData.Values["section"]
                    ?? Request.QueryString["section"];
                    string search = (string)Page.RouteData.Values["search"]
                    ?? Request.QueryString["search"];

                    string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary() {
                    {"section", selectedSection},
                    {"search", search},
                    {"page", i }
                    }).VirtualPath;
                    Response.Write(
                    String.Format("<a href='{0}'>{1}</a>",
                    path, i));
                }
            }


        %>
    </div>

</asp:Content>
