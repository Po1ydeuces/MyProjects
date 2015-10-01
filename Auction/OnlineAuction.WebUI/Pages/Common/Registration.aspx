<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Catalog.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineAuction.WebUI.Pages.Common.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCatalog" runat="server">
    <div id="ctlgmap"></div>
    <div class="catalogcontent">
        <asp:MultiView ID="RegMultiView" runat="server">
            <asp:View ID="reg" runat="server">
                <div id="regarea">
                    <br />
                    <br />
                    Логин
                    <asp:RequiredFieldValidator ID="LoginReqValidator" runat="server" ControlToValidate="loginBox"
                        ErrorMessage="Логин не введен!" ForeColor="Red" Display="Dynamic"> *
                    </asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="loginBox" runat="server" />
                    <br />
                    Пароль
                    <asp:RequiredFieldValidator ID="PasswordReqValidator" runat="server" ControlToValidate="passBox"
                        ErrorMessage="Пароль не введен!" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="passBox" runat="server" TextMode="Password" />
                    <br />
                    Электронная почта
                    <asp:RequiredFieldValidator ID="EmailReqValiadator" runat="server" ControlToValidate="emailBox"
                        ErrorMessage="E-mail не введен!" ForeColor="Red" Display="Dynamic">*
                    </asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="emailBox" runat="server" TextMode="Email" MaxLength="50" />
                    <br />
                    <div id="regbtnarea">
                        <asp:Button ID="regButton" runat="server" OnClick="RegButton_Click"
                            Text="Регистрация"
                            ValidationGroup="Group1" Width="150px" CssClass="changebtn" Height="25px" />
                        <br />
                    </div>
                    <asp:ValidationSummary ID="RegistrationSummary" runat="server" ForeColor="Red" DisplayMode="List" />
                    <br />
                    <br />

                    <asp:RegularExpressionValidator ID="LoginExpValidator" runat="server" ControlToValidate="loginBox"
                        Display="None" ErrorMessage="Неверный формат логина (от 4-x до 25-ти символов)"
                        ValidationExpression="^[a-zA-Z0-9-_\.]{4,25}$">
                    </asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="PasswordExpValidator" runat="server" ControlToValidate="passBox"
                        Display="None" ErrorMessage="Неверный формат пароля (от 6-ти до 20-ти символов)"
                        ValidationExpression="^[a-zA-Z0-9]{6,20}$">
                    </asp:RegularExpressionValidator>

                    <asp:RegularExpressionValidator ID="EmailExpValidator" runat="server" ControlToValidate="emailBox"
                        Display="None" ErrorMessage="Неверный формат e-mail"
                        ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$">
                    </asp:RegularExpressionValidator>

                    <asp:CustomValidator ID="EmailCheckValidator" runat="server" Display="None"
                        ErrorMessage="Пользователь с таким e-mail уже зарегестрирован"
                        OnServerValidate="EmailCheckValidator_ServerValidate">
                    </asp:CustomValidator>

                    <asp:CustomValidator ID="UserExistValidator" runat="server" Display="None"
                        ErrorMessage="Пользователь с таким логином уже зарегестрирован"
                        OnServerValidate="UserExistValidator_ServerValidate">
                    </asp:CustomValidator>

                </div>
            </asp:View>
            <asp:View ID="endreg" runat="server">
                <div id="congreg">
                    <h2>Регистрация прошла успешно!</h2>
                    <h4>Войдите под своими учетными данными.</h4>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
