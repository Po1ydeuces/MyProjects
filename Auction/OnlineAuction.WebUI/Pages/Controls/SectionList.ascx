<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionList.ascx.cs" Inherits="OnlineAuction.WebUI.Pages.Control.SectionList" %>
<%@ Import Namespace="OnlineAuction.Logic.Domains" %>
<%@ Import Namespace="OnlineAuction.WebUI.Models" %>


<asp:LinkButton ID="AllLinkBtn" runat="server" CausesValidation="False" OnClick="AllLinkBtn_Click">Все</asp:LinkButton>

<%

    if (GetSection().Any())
        foreach (Section section in GetSection())
            Response.Write(CreateUrl(section.NameSection));


%>
