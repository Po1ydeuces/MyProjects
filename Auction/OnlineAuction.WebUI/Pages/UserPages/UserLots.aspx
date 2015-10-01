<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="UserLots.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.UserPages.UserLots" %>

<%@ Import Namespace="OnlineAuction.Logic.Domains" %>
<%@ Import Namespace="OnlineAuction.WebUI.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <div id="ctlgmap"></div>
    <div class="mainsection">
        <div id="userlots">
            <%
                if (GetUserLots().Any())
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
                    foreach (UserLot userLot in GetUserLots())
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
                        UrlCreater.CreateUrl(userLot.Lot),
                        userLot.Lot.Name,
                        userLot.Lot.CurrentPrice,
                        userLot.StatusLot.NameStatus,
                        CreateUrl(userLot)
                        )
                        );

                    }
                    Response.Write(String.Format("</table>"));
                }
                else
                    Response.Write("Вы ещё не участвовали в аукционе.");
            %>
            <div id="addbtnarea">
                <asp:Button ID="addBtn" runat="server" Text="Добавить лот"
                    CssClass="changebtn" Height="25px" Width="150px" OnClick="addBtn_Click" />
            </div>
        </div>
    </div>
</asp:Content>
