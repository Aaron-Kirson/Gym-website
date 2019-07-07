<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountOptions.aspx.cs" Inherits="ProjectCIS.AccountOptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <h1 style="text-align: center; ">
        <strong>Account Page</strong></h1>
<h2 class="text-left">
    <strong>Go to your membeship page</strong></h2>
<p>
    <strong>
    <asp:Button ID="MembershipBtn" runat="server" PostBackUrl="~/customerMembership.aspx" Text="My Membership" />
    </strong>
</p>
<h2 class="text-left">
    <strong>Change my password</strong></h2>
<p>
    <asp:Button ID="Button1" runat="server" PostBackUrl="~/Account.aspx" Text="Password Change" />
</p>
    </asp:Content>
