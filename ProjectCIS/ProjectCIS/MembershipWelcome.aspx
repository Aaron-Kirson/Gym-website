<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MembershipWelcome.aspx.cs" Inherits="ProjectCIS.MembershipWelcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <h1 class="text-center">Start your journey today</h1>
    <p>
        <asp:Image ID="Image1" runat="server" Width="100%" ImageUrl="~/Images/membership.jpg" />
    </p>
    <h2 class="text-center">Membership prices</h2>
    <p class="text-left">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Grid" DataKeyNames="Id" DataSourceID="SqlDataSource1" Width="100%">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Membership's available" SortExpression="name" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" SelectCommand="SELECT * FROM [memberships]"></asp:SqlDataSource>
    </p>
<p class="text-left">
        <asp:Button ID="joinBtn" runat="server" OnClick="joinBtn_Click" Text="Join me up" />
    </p>
</asp:Content>
