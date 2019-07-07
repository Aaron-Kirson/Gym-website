<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menu2.aspx.cs" Inherits="ProjectCIS.menu2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <h2> Products available to purchase</h2>
    <p> 
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/shopbanner.png" Width="100%" />
    </p>
    <h2 class="text-center"> 
        please choose a product if you would like to enquire about it!</h2>
    <asp:Panel ID="pnlShop" runat="server" Wrap="False"  > </asp:Panel>
        <div style="clear: both"></div>
   
     
   
</asp:Content>
