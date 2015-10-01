<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CabinetList.ascx.cs" Inherits="OnlineAuction.WebUI.Pages.Controls.CabinetList" %>
<%@ Import Namespace="OnlineAuction.Logic.Domains" %>
<%@ Import Namespace="OnlineAuction.Logic.Models" %>
<%@ Import Namespace="OnlineAuction.WebUI.Models" %>

<ul>
    <li>
        <asp:LinkButton ID="userInfo" runat="server" Text="О пользователе" CausesValidation="False" OnClick="userInfo_Click" /></li>
    <li>
        <asp:LinkButton ID="editInfo" runat="server" Text="Изменение данных" CausesValidation="False" OnClick="editInfo_Click" /></li>
    <li>
        <asp:LinkButton ID="userLots" runat="server" Text="Мои лоты" CausesValidation="False" OnClick="userLots_Click" /></li>
    <li>
        <asp:LinkButton ID="editLots" runat="server" Text="Управление лотами" CausesValidation="False" OnClick="editLots_Click" /></li>
    <li>
        <asp:LinkButton ID="editSections" runat="server" Text="Управление разделами" CausesValidation="False" OnClick="editSections_Click" /></li>
    <li>
        <asp:LinkButton ID="editUsers" runat="server" Text="Управление пользователями" CausesValidation="False" OnClick="editUsers_Click" /></li>
    <li>
        <asp:LinkButton ID="editPass" runat="server" Text="Смена пароля" OnClick="editPass_Click" /></li>


</ul>
