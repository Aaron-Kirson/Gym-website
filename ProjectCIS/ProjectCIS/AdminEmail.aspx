<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminEmail.aspx.cs" Inherits="ProjectCIS.AdminEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <p style="font-size: xx-large">
        <strong>Send email to user</strong></p>
<p>
    <strong>View customer email list</strong></p>
<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            <asp:BoundField DataField="firstName" HeaderText="firstName" SortExpression="firstName" />
            <asp:BoundField DataField="surname" HeaderText="surname" SortExpression="surname" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" SelectCommand="SELECT [Id], [username], [firstName], [surname], [email] FROM [customers]"></asp:SqlDataSource>
</p>
    <p>
        Email to:
        <asp:TextBox ID="emailTxt" runat="server" Width="484px" required TextMode="Email"></asp:TextBox>
</p>
    <p>
        Email subject:
        <asp:TextBox ID="subText" runat="server" Width="449px" required></asp:TextBox>
</p>
    <p>
        Email body:
        <asp:TextBox ID="bodyTxt" runat="server" Height="65px" TextMode="MultiLine" Width="475px" required></asp:TextBox>
</p>
<p>
    <asp:Button ID="sendBtn" runat="server" OnClick="sendBtn_Click" Text="Send email" />
    </p>
    <p>
        <asp:Label ID="errorlbl" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
