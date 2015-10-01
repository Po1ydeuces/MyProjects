<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="EditLot.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.UserPages.EditLot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <script>
        function getName(str) {
            if (str && !/\.(jpg|jpeg|bmp|gif|png)$/i.test(str)) {

                alert("Неверный тип файла!");

            }
            else if (str) {

                if (str.lastIndexOf('\\')) {
                    var i = str.lastIndexOf('\\') + 1;
                }
                else {
                    var i = str.lastIndexOf('/') + 1;
                }

                var filename = str.slice(i);
                var uploaded = document.getElementById("fileformlabel");
                uploaded.innerHTML = filename;
            }
        }
    </script>

    <script type="text/javascript" src="../../Content/Scripts/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Scripts/imageShow.js"></script>

    <div id="ctlgmap"></div>
    <div class="mainsection">
        <asp:MultiView ID="MultiView" runat="server">
            <asp:View ID="changeData" runat="server">
                <div id="changearea">
                    Название
                    <asp:RequiredFieldValidator ID="nameReqValidator" runat="server" ControlToValidate="nameBox"
                        ErrorMessage="Название не указано!" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="nameBox" runat="server" MaxLength="150" />
                    <br />
                    Раздел
                    <br />
                    <asp:DropDownList ID="ddlSection" runat="server" DataSourceID="eds" DataTextField="NameSection" DataValueField="NameSection" CssClass="сhangetxt" />
                    <asp:EntityDataSource ID="eds" runat="server" ConnectionString="name=AuctionEntities" DefaultContainerName="AuctionEntities" EnableFlattening="False"
                        EntitySetName="Sections" EntityTypeFilter="Section" Select="it.[NameSection]" OrderBy="it.[NameSection]">
                    </asp:EntityDataSource>
                    <br />
                    Начало торгов
                    <br />
                    <asp:TextBox ID="startDateBox" runat="server" MaxLength="150" Enabled="False" />
                    <br />
                    Окончание торгов
                    <br />
                    <asp:DropDownList ID="ddlEndDate" runat="server" CssClass="сhangetxt">
                        <asp:ListItem Selected="True">1 час</asp:ListItem>
                        <asp:ListItem>24 часа</asp:ListItem>
                        <asp:ListItem>7 дней</asp:ListItem>
                        <asp:ListItem>1 месяц</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    Начальная цена
                    <asp:RequiredFieldValidator ID="startPriceReqValidator" runat="server" ControlToValidate="startPriceBox"
                        ErrorMessage="Начальная цена не указана!" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="startPriceBox" runat="server" MaxLength="150" TextMode="Number" />
                    <br />
                    Минимальная ставка
                    <asp:RequiredFieldValidator ID="tickReqValidator" runat="server" ControlToValidate="tickBox"
                        ErrorMessage="Минимальная ставка не указана!" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="tickBox" runat="server" MaxLength="150" TextMode="Number" />

                    <br />
                    Описание
                    <asp:RequiredFieldValidator ID="descReqValidator" runat="server" ControlToValidate="descBox"
                        ErrorMessage="Описание не указано!" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="descBox" runat="server" TextMode="MultiLine" MaxLength="100" CssClass="сhangetxt" Width="300px" Height="50px" />
                    <br />
                    Изображение
                    <br />
                    <br />
                    <div>
                        <div class="fileform">
                            <div id="fileformlabel"></div>
                            <div class="selectbutton">Обзор</div>
                            <input type="file" name="filefield" accept="image/*"
                                id="filefield" onchange="getName(this.value);" />
                        </div>
                    </div>
                    <br />

                    <div id="img-container">
                        <% if (lot != null)
                               Response.Write(String.Format(@"<img src='{0}' alt='Img'>", String.Format(@"/DataBase/Images/{0}", lot.Img))); %>
                    </div>

                    <br />
                    <br />
                    <asp:Button ID="saveBtn" runat="server" Text="Сохранить"
                        CssClass="changebtn" OnClick="saveBtn_Click" Height="25px" Width="150px" />
                    &nbsp
                    <asp:Button ID="cancelBtn" runat="server" Text="Отменить"
                        CssClass="changebtn" OnClick="cancelBtn_Click" Height="25px" Width="150px" CausesValidation="False" />
                    <br />
                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="RegistrationSummary" runat="server" ForeColor="Red" DisplayMode="List" />

                    <asp:RangeValidator ID="priceRange" ControlToValidate="startPriceBox" MinimumValue="1" MaximumValue="999999999.99"
                        Type="Currency" Display="None" ErrorMessage="Неверное значение начальной цены!" runat="server" />

                    <asp:RangeValidator ID="tickRange" ControlToValidate="tickBox" MinimumValue="1" MaximumValue="999999999.99"
                        Type="Currency" Display="None" ErrorMessage="Неверное значение минимальной ставки!" runat="server" />


                    <br />
                    <br />

                </div>
            </asp:View>
            <asp:View ID="endChange" runat="server">
                <div id="congreg">
                    <h2>Данные успешно изменены!</h2>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
