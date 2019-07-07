<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectCIS.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <p style="font-size: medium">
        <strong>please fill in your information below if you have registered already otherwise press the register button.</strong></p>
<p class="text-left">
    <strong>Username:
    <asp:TextBox ID="usernameTxt" runat="server" OnTextChanged="TextBox1_TextChanged" Height="23px"></asp:TextBox>
    </strong>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="usernameTxt" ErrorMessage="please fill in username field" ForeColor="Red"></asp:RequiredFieldValidator>
</p>
<p class="text-left">
    <strong>Password:
    </strong>
    <asp:TextBox ID="passwordtxt" runat="server" TextMode="Password" Height="28px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="passwordtxt" ErrorMessage="please fill in password field" ForeColor="Red"></asp:RequiredFieldValidator>
</p>
    <p class="text-left">
        <asp:DropDownList ID="UserDropList" runat="server" Width="125px">
            <asp:ListItem>User</asp:ListItem>
            <asp:ListItem>Admin</asp:ListItem>
        </asp:DropDownList>
</p>
<p class="text-left">
    <asp:Button ID="loginbtn" runat="server" OnClick="loginbtn_Click" Text="Login" />
</p>
<p class="text-left">
    <asp:Label ID="errorlbl" runat="server" ForeColor="Red"></asp:Label>
</p>
</asp:Content>
