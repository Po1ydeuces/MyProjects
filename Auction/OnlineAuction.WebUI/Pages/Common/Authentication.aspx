<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Catalog.Master" AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Common.Authentication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCatalog" runat="server">
    <div id="ctlgmap"></div>
    <div id="loginarea" class="catalogcontent">
        <asp:Login ID="LoginControl" runat="server" FailureText="Неверный логин или пароль.Повторите попытку."
            OnAuthenticate="LoginControl_Authenticate" RenderOuterTable="False" TitleText="" VisibleWhenLoggedIn="False" FailureTextStyle-HorizontalAlign="Left" ValidatorTextStyle-ForeColor="Red" TextLayout="TextOnTop">
            <LayoutTemplate>
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Логин </asp:Label>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                    ControlToValidate="userName" ErrorMessage="*" ForeColor="Red" ToolTip="Логин обязателен" ValidationGroup="LoginControl" />
                <br />
                <asp:TextBox ID="userName" runat="server" />
                <br />
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Пароль </asp:Label>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="*" ForeColor="Red" ToolTip="Пароль обязателен" ValidationGroup="LoginControl" />
                <br />
                <asp:TextBox ID="password" runat="server" TextMode="Password" />
                <br />
                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Войти" ValidationGroup="LoginControl" CssClass="changebtn" Height="25px" Width="150px" />
                <br />
                <div id="loginfail">
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                </div>
                <br />
            </LayoutTemplate>
            <FailureTextStyle HorizontalAlign="Right" />
        </asp:Login>
    </div>
</asp:Content>
