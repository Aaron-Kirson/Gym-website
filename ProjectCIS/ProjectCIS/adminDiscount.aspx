<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminDiscount.aspx.cs" Inherits="ProjectCIS.adminDiscount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <p style="font-size: x-large">
        <strong>Add discount</strong></p>
    <p>
        <strong>Discount amount (£):&nbsp;
        <asp:TextBox ID="amountTxt" runat="server" required TextMode="Number"></asp:TextBox>
        </strong>
    </p>
    <p>
        <strong>Discount code:
        </strong>
        <asp:TextBox ID="codeTxt" runat="server" required TextMode="Number"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create deal" />
    </p>
    <p>
        <asp:Label ID="errorlbl" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
