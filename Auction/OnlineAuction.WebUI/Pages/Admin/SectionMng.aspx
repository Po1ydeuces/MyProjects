<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="SectionMng.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Admin.SectionMng" %>

<%@ Import Namespace="OnlineAuction.Logic.Domains" %>
<%@ Import Namespace="OnlineAuction.WebUI.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <script>
        function delsection() {
            if (confirm("Bы уверены, что хотите удалить этот раздел?"))
                return true;
            else
                return false;
        }
    </script>

    <div id="ctlgmap"></div>
    <div class="mainsection">
        <div id="userlots">
            <%
                if (GetSections().Any())
                {
                    Response.Write(String.Format(@"
                    <table>
                    <tr id='head'>
                    <td>№</td>
                    <td>Название</td>
                    <td></td>
                    <td></td>
                    </tr>"));
                    int k = 0;
                    foreach (Section section in GetSections())
                    {
                        k++;
                        Response.Write(String.Format(@"
                        <tr>
                        <td>{0}</td>
                        <td>{1}</td>
                        <td><div id='userlink'>{2}</div></td>
                        <td><button class='changebtn' id='delbtn' name='remove'
                        type='submit' value={3} onclick='return delsection()'>Удалить</button></td>
                        </tr>",
                        k,
                        section.NameSection,
                        CreateUrl(section),
                        section.Id
                        )
                        );
                    }
                    Response.Write(String.Format("</table>"));
                }

            %>
            <div id="addbtnarea">
                <asp:Button ID="addBtn" runat="server" Text="Добавить раздел"
                    CssClass="changebtn" Height="25px" Width="150px" OnClick="addBtn_Click" />
            </div>
        </div>
    </div>
</asp:Content>
