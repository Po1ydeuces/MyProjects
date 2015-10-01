<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="OnlineAuction.WebUI.Pages.Controls.Search" %>
<asp:TextBox ID="FindBox" runat="server" Width="165px" placeholder="Название лота"></asp:TextBox>
<asp:Button ID="FindBtn" runat="server" Text="Поиск" Width="77px" CssClass="srchbtn" OnClick="FindBtn_Click" />