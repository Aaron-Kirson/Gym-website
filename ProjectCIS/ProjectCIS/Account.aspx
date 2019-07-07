<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="ProjectCIS.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />

    <h1 class="text-center" style="font-size: xx-large"><strong>My account</strong></h1>    
    <p style="font-size: x-large">
        <strong>Do you wish to change your password?</strong></p>
    <p>
        <strong><span style="font-size: x-large">my new password
        </span>
        <asp:TextBox ID="changeTxtbx" runat="server" style="font-size: x-large"></asp:TextBox>
        </strong>
    </p>
    <p>
        <strong>
        <asp:Button ID="ChangeBtn" runat="server" OnClick="ChangeBtn_Click" Text="Change password" style="font-size: x-large" />
        </strong>
    </p>
    <p>
        <asp:Label ID="errorlbl" runat="server"></asp:Label>
    </p>
</asp:Content>
