<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="LotsMng.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Admin.LotsMng" %>

<%@ Import Namespace="OnlineAuction.Logic.Domains" %>
<%@ Import Namespace="OnlineAuction.WebUI.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <div id="ctlgmap"></div>
    <div class="mainsection">
        <div id="userlots">
            <%
                if (GetLots().Any())
                {
                    Response.Write(String.Format(@"
                    <table>
                    <tr id='head'>
                    <td>№</td>
                    <td>Название</td>
                    <td>Текущая цена</td>
                    <td>Статус</td>
                    <td></td>
                    </tr>"));
                    int k = 0;
                    foreach (Lot lot in GetLots())
                    {
                        k++;
                        Response.Write(String.Format(@"
                        <tr>
                        <td>{0}</td>
                        <td><a href='{1}'>{2}</a></td>
                        <td>{3:c}</td>
                        <td>{4}</td>
                        <td><div id='userlink'>{5}</div></td>
                        </tr>",
                        k,
                        UrlCreater.CreateUrl(lot),
                        lot.Name,
                        lot.CurrentPrice,
                        lot.Status ? "Активен" : "Неактивен",
                        CreateUrl(lot)
                        )
                        );

                    }
                    Response.Write(String.Format("</table>"));
                }

            %>
        </div>
    </div>
</asp:Content>
