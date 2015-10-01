<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PswValid.ascx.cs" Inherits="OnlineAuction.WebUI.Pages.Controls.PswValid" %>



<asp:MultiView ID="ChangePswView" runat="server">
    <asp:View ID="PswView" runat="server">
        <div id="regarea">
            Старый пароль
            <asp:RequiredFieldValidator ID="oldPswReqValidator" runat="server" ControlToValidate="oldPswBox"
                ErrorMessage="Старый пароль не введен!" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="oldPswBox" runat="server" TextMode="Password" />

            <br />
            Новый пароль
            <asp:RequiredFieldValidator ID="newPswReqValidator" runat="server" ControlToValidate="newPswBox"
                ErrorMessage="Новый пароль не введен!" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="newPswBox" runat="server" TextMode="Password" />

            <br />
            Подтверждение пароля
            <asp:RequiredFieldValidator ID="secPswReqValidator" runat="server" ControlToValidate="subNewPswBox"
                ErrorMessage="Новый пароль не подтвержден!" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="subNewPswBox" runat="server" TextMode="Password" />

            <br />

            <br />
            <asp:Button ID="PswSaveBtn" runat="server" Text="Сохранить"
                OnClick="PswSaveBtn_Click" CssClass="changebtn" Height="25px" Width="150px" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor="Red" DisplayMode="List" />
            <asp:RegularExpressionValidator ID="oldPswExpValidator" runat="server" ControlToValidate="oldPswBox"
                Display="None" ErrorMessage="Неверный формат старого пароля (от 6-ти до 20-ти символов)"
                ValidationExpression="^[a-zA-Z0-9]{6,20}$"></asp:RegularExpressionValidator>

            <asp:RegularExpressionValidator ID="newPswExpValidator" runat="server" ControlToValidate="newPswBox"
                Display="None" ErrorMessage="Неверный формат нового пароля (от 6-ти до 20-ти символов)"
                ValidationExpression="^[a-zA-Z0-9]{6,20}$"></asp:RegularExpressionValidator>

            <asp:CompareValidator ID="pasCompare" runat="server" ControlToCompare="newPswBox"
                ControlToValidate="SubNewPswBox" Display="None"
                ErrorMessage="Пароли не совпадают!"></asp:CompareValidator>

            <asp:CustomValidator ID="PswValidator" runat="server" Display="None"
                ErrorMessage="Старый пароль неверен"
                OnServerValidate="PswValidator_ServerValidate"></asp:CustomValidator>

        </div>
    </asp:View>
    <asp:View ID="CongView" runat="server">
        <div id="congreg">
            <h2>Пароль успешно изменен</h2>
        </div>
    </asp:View>
</asp:MultiView>
