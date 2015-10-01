<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Logon.ascx.cs" Inherits="OnlineAuction.WebUI.Pages.Controls.Logon" %>

<asp:LoginView ID="LoginViewText" runat="server">
    <AnonymousTemplate>
        <div id="logregforgot">
            <asp:LinkButton ID="loginBtn" runat="server" CausesValidation="False" OnClick="loginBtn_Click">Вход </asp:LinkButton>
            или
            <asp:LinkButton ID="regBtn" runat="server" CausesValidation="False" OnClick="regBtn_Click"> Регистрация</asp:LinkButton>
        </div>
    </AnonymousTemplate>
    <LoggedInTemplate>
        <div id="loged">
            Здравствуйте,
            <asp:LoginName ID="LoginName" runat="server" />
            !
            <asp:LoginStatus ID="LoginStatus" runat="server" LogoutText="Выйти" OnLoggingOut="LoginStatus_LoggingOut" />
        </div>
        <div id="navigation">
            <ul>
                <li>
                    <asp:LinkButton ID="MainLinkBtn" runat="server" CausesValidation="False" OnClick="MainLinkBtn_Click">Главная</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="CatalogLinkBtn" runat="server" CausesValidation="False" OnClick="CatalogLinkBtn_Click">Каталог</asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="UserCabinetLinkBtn" runat="server" CausesValidation="False" OnClick="UserCabinetLinkBtn_Click">Личный кабинет</asp:LinkButton></li>
            </ul>
        </div>
    </LoggedInTemplate>

</asp:LoginView>
