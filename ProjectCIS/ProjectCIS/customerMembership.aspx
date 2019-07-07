<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerMembership.aspx.cs" Inherits="ProjectCIS.customerMembership" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <h1>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    My gym membership</h1>
    <p>
        <asp:GridView ID="MembershipGrid" runat="server" AutoGenerateColumns="False" CssClass="Grid">
            <Columns>
                <asp:BoundField DataField="membership" HeaderText="Membership" />
                <asp:BoundField DataField="price" HeaderText="Price of membership" />
                <asp:BoundField DataField="startTime" HeaderText="start of membership" />
                <asp:BoundField DataField="endTime" HeaderText="end of membership" />
            </Columns>
        </asp:GridView>
    </p>
<p>
    <asp:Label ID="errorlbl" runat="server"></asp:Label>
    </p>
</asp:Content>
