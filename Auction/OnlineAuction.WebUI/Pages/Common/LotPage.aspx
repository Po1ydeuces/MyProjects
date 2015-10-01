<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Catalog.Master" AutoEventWireup="true" CodeBehind="LotPage.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Common.LotPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCatalog" runat="server">
    <div id="ctlgmap"></div>
    <div id="lot" class="catalogcontent">

        <%
            if (Lot != null)
            {
                Response.Write(String.Format(@"
                <div id='lotimg'>
                <img src='{0}' alt='Img'>
                </div>
                <div id='lottitle'>
                {1}
                </div>
                <div id='lotparam'>
                <h4>Раздел:</h4> {2}</br>
                <h4>Начало торгов:</h4> {3} </br>
                <h4>Окончание торгов:</h4> {4}</br>
                <h4>Продавец:</h4> {5}</br>
                <div id='lotprice'>
                <h4>Стартовая цена:</h4> {6:c}</br>
                <h4>Текущая цена:</h4> {7:c}</br>
                <h4>Минимальная ставка:</h4> {8:c}</br>
                </div>
                </div>

                <div id='lotdesc'>
                <h4>Описание:</h4>
                {9}
                </div>",

                String.Format(@"/DataBase/Images/{0}",
                Lot.Img),
                Lot.Name,
                Lot.Section.NameSection,
                Lot.StartDate.ToString("dd.MM.yyyy, HH:mm"),
                Lot.EndDate.ToString("dd.MM.yyyy, HH:mm"),
                GetSeller(Lot.IdLot),
                Lot.StartPrice,
                Lot.CurrentPrice,
                Lot.Tick,
                Lot.Description));
            }
            else
                Response.RedirectToRoute("notfound");
        %>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="updPanel" runat="server">
            <ContentTemplate>
                <div id="lotbtns">

                    <asp:Button ID="BuyBtn" runat="server" Text="Сделать ставку" OnClick="BuyBtn_Click" />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
