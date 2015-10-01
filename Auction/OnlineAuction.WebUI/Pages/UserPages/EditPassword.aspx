<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="EditPassword.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.UserPages.EditPassword" %>

<%@ Register Src="~/Pages/Controls/PswValid.ascx" TagPrefix="OA" TagName="PswValid" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <div id="ctlgmap"></div>
    <div class="mainsection">
        <OA:PswValid runat="server" ID="PswValid" />
    </div>
</asp:Content>
