<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="UsersMng.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Admin.UsersMng" %>

<%@ Import Namespace="OnlineAuction.Logic.Domains" %>
<%@ Import Namespace="OnlineAuction.WebUI.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <div id="ctlgmap"></div>
    <div class="mainsection">
        <div id="userlots">
            <%
                if (GetUsers().Any())
                {
                    Response.Write(String.Format(@"
                    <table>
                    <tr id='head'>
                    <td>№</td>
                    <td>Логин</td>
                    <td>ФИО</td>
                    <td>Роль</td>
                    <td></td>
                    </tr>"));
                    int k = 0;
                    foreach (User user in GetUsers())
                    {
                        k++;
                        Response.Write(String.Format(@"
                        <tr>
                        <td>{0}</td>
                        <td>{1}</td>
                        <td>{2}</td>
                        <td>{3}</td>
                        <td><div id='userlink'>{4}</div></td>
                        </tr>",
                        k,
                        user.Login,
                        user.Name,
                        user.Role.NameRole,
                        CreateUrl(user)
                        )
                        );

                    }
                    Response.Write(String.Format("</table>"));
                }

            %>
        </div>
    </div>

</asp:Content>
