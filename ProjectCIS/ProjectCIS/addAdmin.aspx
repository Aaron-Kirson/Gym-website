<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addAdmin.aspx.cs" Inherits="ProjectCIS.addAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add new admin</h1>
    <p>
        <strong>Please add an admin by filling in the details below</strong></p>
    <p>
        Admin username:
        <asp:TextBox ID="usernameTxt" runat="server" required></asp:TextBox>
    </p>
    <p>
        Admin password:
        <asp:TextBox ID="passwordTxt" runat="server" required></asp:TextBox>
&nbsp;</p>
    <p>
        <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_Click" Text="Add admin" />
    </p>
    <p>
        <asp:Label ID="errorlbl" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
