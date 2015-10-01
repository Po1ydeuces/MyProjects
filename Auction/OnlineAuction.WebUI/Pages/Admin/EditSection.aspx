<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="EditSection.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Admin.EditSection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <div id="ctlgmap"></div>
    <div class="mainsection">
        <asp:MultiView ID="MultiView" runat="server">
            <asp:View ID="changeData" runat="server">
                <div id="changearea">
                    Название
                    <asp:RequiredFieldValidator ID="NameReqValidator" runat="server" ControlToValidate="nameBox"
                        ErrorMessage="Название не введено!" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="nameBox" runat="server" />
                    <br />
                    <br />

                    <asp:Button ID="saveBtn" runat="server" Text="Сохранить"
                        OnClick="saveBtn_Click" CssClass="changebtn" Height="25px" Width="150px" />
                    &nbsp
                    <asp:Button ID="cancelBtn" runat="server" Text="Отменить"
                        CssClass="changebtn" Height="25px" Width="150px" OnClick="cancelBtn_Click" />
                    <br />
                    <br />
                    <asp:CustomValidator ID="nameCheckValidator" runat="server" Display="None"
                        ErrorMessage="Раздел с таким именем уже существует!"
                        OnServerValidate="nameCheckValidator_ServerValidate">
                    </asp:CustomValidator>

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
