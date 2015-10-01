<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.UserPages.UserInfo" %>

<%@ Register Src="~/Pages/Controls/UserInfoList.ascx" TagPrefix="OA" TagName="UserInfoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <div id="ctlgmap"></div>
    <div class="mainsection">
        <div id="userinfo">
            <OA:UserInfoList runat="server" ID="UserInfoList" />

        </div>
    </div>

</asp:Content>
