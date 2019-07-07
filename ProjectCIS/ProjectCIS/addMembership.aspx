<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addMembership.aspx.cs" Inherits="ProjectCIS.addMembership" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <h1>
        Add new membership</h1>
    <p>
        <strong>Please add membership by filling in information below</strong></p>
    <p>
        name of membership include price in brackets e.g DayPass (£5):&nbsp;&nbsp;
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nameTxt" ErrorMessage="please add membership name (price)" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        price of membership that was added into the brackets above:
        <asp:TextBox ID="pricetxt" runat="server" TextMode="Number"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pricetxt" ErrorMessage="Please add price of membership" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="submitBtn" runat="server" OnClick="submitBtn_Click" Text="Submit membership" />
    </p>
    <p>
        <asp:Label ID="errorlbl" runat="server"></asp:Label>
    </p>
    <br />
</asp:Content>
