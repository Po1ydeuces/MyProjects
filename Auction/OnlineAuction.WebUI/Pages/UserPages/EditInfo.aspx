<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="EditInfo.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.UserPages.EditInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <div id="ctlgmap"></div>
    <div class="mainsection">
        <asp:MultiView ID="MultiView" runat="server">
            <asp:View ID="changeData" runat="server">
                <div id="changearea">
                    ФИО
                    <br />
                    <asp:TextBox ID="nameBox" runat="server" MaxLength="50" />
                    <br />
                    Адрес
                    <br />
                    <asp:TextBox ID="addressBox" runat="server" TextMode="MultiLine"
                        Width="300px" Height="50px" MaxLength="100" CssClass="сhangetxt" />
                    <br />
                    Телефон
                    <br />
                    <asp:TextBox ID="phoneBox" runat="server" TextMode="Phone" MaxLength="50" />
                    <asp:RegularExpressionValidator ID="PhoneExpValidator" runat="server" ControlToValidate="phoneBox"
                        Display="None" ErrorMessage="Неверный формат телефонного номера (пример: 8-705-123-45-67)"
                        ValidationExpression="^[78]?[- .]?(\([0-9]\d{2}\)|[0-9]\d{2})[- .]?\d{3}[- .]?\d{2}[- .]?\d{2}$">
                    </asp:RegularExpressionValidator>
                    <br />

                    <asp:Button ID="saveBtn" runat="server" Text="Сохранить"
                        OnClick="saveBtn_Click" CssClass="changebtn" Height="25px" Width="200px" />
                    <br />
                    <br />
                    <asp:ValidationSummary ID="RegistrationSummary" runat="server" ForeColor="Red" DisplayMode="List" />
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
