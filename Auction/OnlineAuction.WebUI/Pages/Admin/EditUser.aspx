<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Cabinet.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Admin.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderUserCabinet" runat="server">
    <div id="ctlgmap"></div>
    <div class="mainsection">
        <asp:MultiView ID="MultiView" runat="server">
            <asp:View ID="changeData" runat="server">
                <div id="changearea">
                    Логин
                    <br />
                    <asp:TextBox ID="loginBox" runat="server" MaxLength="50" Enabled="False" />
                    <br />
                    Пароль
                    <asp:RequiredFieldValidator ID="PasswordReqValidator" runat="server" ControlToValidate="passBox"
                        ErrorMessage="Пароль не введен!" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="passBox" runat="server" />
                    <br />
                    Роль
                    <br />
                    <asp:DropDownList ID="ddlRoles" runat="server" DataSourceID="eds" DataTextField="NameRole" DataValueField="NameRole" CssClass="сhangetxt"></asp:DropDownList>
                    <asp:EntityDataSource ID="eds" runat="server" ConnectionString="name=AuctionEntities" DefaultContainerName="AuctionEntities" EnableFlattening="False" EntitySetName="Roles" Select="it.[NameRole]">
                    </asp:EntityDataSource>
                    <br />
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
                    <asp:TextBox ID="phoneBox" runat="server" TextMode="Phone" MaxLength="50"></asp:TextBox>
                    <br />
                    Электронная почта
                    <asp:RequiredFieldValidator ID="EmailReqValiadator" runat="server" ControlToValidate="emailBox"
                        ErrorMessage="E-mail не введен!" ForeColor="Red" Display="Dynamic">*
                    </asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="emailBox" runat="server" TextMode="Email" />
                    <br />

                    <asp:Button ID="saveBtn" runat="server" Text="Сохранить"
                        OnClick="saveBtn_Click" CssClass="changebtn" Height="25px" Width="150px" />
                    &nbsp
                    <asp:Button ID="cancelBtn" runat="server" Text="Отменить"
                        CssClass="changebtn" Height="25px" Width="150px" OnClick="cancelBtn_Click" />
                    <br />
                    <br />
                    <asp:CustomValidator ID="EmailCheckValidator" runat="server" Display="None"
                        ErrorMessage="Пользователь с таким e-mail уже зарегестрирован"
                        OnServerValidate="EmailCheckValidator_ServerValidate">
                    </asp:CustomValidator>


                    <asp:RegularExpressionValidator ID="PasswordExpValidator" runat="server" ControlToValidate="passBox"
                        Display="None" ErrorMessage="Неверный формат пароля (от 6-ти до 20-ти символов)"
                        ValidationExpression="^[a-zA-Z0-9]{6,20}$">
                    </asp:RegularExpressionValidator>


                    <asp:RegularExpressionValidator ID="EmailExpValidator" runat="server" ControlToValidate="emailBox"
                        Display="None" ErrorMessage="Неверный формат e-mail"
                        ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$">
                    </asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="PhoneExpValidator" runat="server" ControlToValidate="phoneBox"
                        Display="None" ErrorMessage="Неверный формат телефонного номера (пример: 8-705-123-45-67)"
                        ValidationExpression="^[78]?[- .]?(\([0-9]\d{2}\)|[0-9]\d{2})[- .]?\d{3}[- .]?\d{2}[- .]?\d{2}$">
                    </asp:RegularExpressionValidator>

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
