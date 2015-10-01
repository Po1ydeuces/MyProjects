<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Common.Main"
    MasterPageFile="~/Pages/Master/Catalog.master" %>

<%@ Import Namespace="OnlineAuction.Logic.Domains" %>
<%@ Import Namespace="OnlineAuction.WebUI.Models" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderRandomLot" runat="server">
    <script type="text/javascript" src="../../Content/Scripts/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Scripts/randomLot.js"></script>
    <div id="img-container">
    </div>
    <div id="text-container">
    </div>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCatalog" runat="server">
    <link href="/Content/Styles/owl.carousel.css" rel="stylesheet" />
    <link href="/Content/Styles/owl.theme.css" rel="stylesheet" />
    <script src="/Content//Scripts/jquery-2.1.4.js"></script>
    <script src="/Content/Scripts/owl.carousel.js"></script>

    <script>
        jQuery(document).ready(function () {
            var owlWrap = $('.mainsection');
            if (owlWrap.length > 0) {
                if (jQuery().owlCarousel) {
                    owlWrap.each(function () {
                        var carousel = $(this).find('.owl-carousel');

                        carousel.owlCarousel({
                            itemsCustom: [
                            [800, 4]]
                        });


                    });
                };
            };
        });
    </script>


    <div id="ctlgmap"></div>

    <div class="mainsection">
        <div class="title">
            Активные лоты
            <div class="owl-controls clickable">
                <div class="owl-pagination">
                    <div class="owl-page active">
                        <span class=""></span>
                    </div>
                </div>
            </div>

        </div>
        <div id="container1" class="owl-carousel">
            <%

                if (GetActiveLots().Any())
                {
                    foreach (Lot lots in GetActiveLots())
                    {
                        var date = lots.EndDate - DateTime.Now;
                        Response.Write(String.Format(@"
                        <div class='item'>
                        <div class='blockimg'>
                        <img src='{0}' alt='Img'><br>
                        </div>
                        <a href='{1}'>{2}</a><br/><br/>
                        <h4>Окончание торгов:</h4> <br/>{3}дн. {4}ч. <br/><br/>
                        <h4>Текущая цена:</h4><br/>{5:c}
                        </div>",
                        String.Format("/DataBase/Images/{0}", lots.Img),
                        UrlCreater.CreateUrl(lots), lots.Name,
                        date.Days, date.Hours, lots.CurrentPrice));
                    }
                }
            %>
        </div>
    </div>

    <div class="mainsection">
        <div class="title">
            Завершенные лоты

            <div class="owl-controls clickable" style="display: block;">
                <div class="owl-pagination">
                    <div class="owl-page active">
                        <span class=""></span>
                    </div>
                </div>
            </div>
        </div>
        <div id="container2" class="owl-carousel">
            <%

                if (GetInactiveLots().Any())
                {
                    foreach (Lot lots in GetInactiveLots())
                    {
                        var date = lots.EndDate - DateTime.Now;
                        Response.Write(String.Format(@"
                        <div class='item'>
                        <div class='blockimg'>
                        <img src='{0}' alt='Img'><br>
                        </div>
                        <a href='{1}'>{2}</a><br/><br/>
                        <h4>Окончание торгов:</h4> <br/>Завершены<br/><br/>
                        <h4>Текущая цена:</h4><br/>{3:c}
                        </div>",
                        String.Format("/DataBase/Images/{0}", lots.Img),
                        UrlCreater.CreateUrl(lots), lots.Name,
                        lots.CurrentPrice));
                    }
                }
            %>
        </div>
    </div>
</asp:Content>
