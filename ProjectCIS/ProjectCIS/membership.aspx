<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="membership.aspx.cs" Inherits="ProjectCIS.membership" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <h1>
        <strong>Thanks for your interest in signing up for the gym</strong></h1>
  
        <h2>
  
        <strong>Please choose which membership you would like to obtain.</strong></h2>
    <asp:RadioButtonList ID="GymList" runat="server" OnSelectedIndexChanged="GymList_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="Price" AutoPostBack="True">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:RadioButtonList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" SelectCommand="SELECT [name], [Price] FROM [memberships]"></asp:SqlDataSource>
    <p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="GymList" ErrorMessage="please select a membership to purchase" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <h2>
        <strong>Please choose a date for when you want to start your membership </strong></h2>
    <p>
        <asp:Calendar ID="startCal" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="FullMonth" Width="100%" SelectedDate="03/12/2018 14:07:46" VisibleDate="2018-03-12">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
    </p>
    <h2>
        <strong>Please enter your secruity code to the details you registered with</strong></h2>
    <p class="text-left">
        <strong>Secruity Code (3 digits back of card)</strong>:
        <asp:TextBox ID="CWTxtbx" runat="server" TextMode="Number" required></asp:TextBox>
        <asp:RegularExpressionValidator ID="cvCheck" runat="server" ControlToValidate="CWTxtbx" ErrorMessage="please add only 3 digits (e.g 123) " ForeColor="Red" ValidationExpression="^[0-9]{3}$"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Button ID="PayBtn" runat="server" Text="Pay for membership" OnClick="Button1_Click" />
    </p>
    <p class="text-left">
        <asp:Label ID="errorLbl" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
