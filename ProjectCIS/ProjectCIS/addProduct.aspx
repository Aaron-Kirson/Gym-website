<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="ProjectCIS.addProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>    <link href="Styles/StyleSheet.css" rel="stylesheet" />
        <strong>Add product to system</strong></h1>
    <p>
        <strong>Please add products by filling in the details below</strong></p>
<p>
    Name of product (Include name, flavour, size):&nbsp;
    <asp:TextBox ID="namelbl" runat="server" required Width="217px"></asp:TextBox>
</p>
<p>
    Price of product:&nbsp;
    <asp:TextBox ID="pricelbl" runat="server" required TextMode="Number" ></asp:TextBox>
</p>
<p>
    Description of product:
    <asp:TextBox ID="DescLbl" runat="server" Width="626px" required Height="66px" TextMode="MultiLine"></asp:TextBox>
</p>
<p>
    Add image Url:&nbsp;&nbsp;
    <asp:FileUpload ID="PictureUpload" runat="server"  accept=".png,.jpg,.jpeg,.gif" />
</p>
    <p>
    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
     ControlToValidate="PictureUpload"
     ErrorMessage="Only images can be uploaded!" 
     ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.JPG|.gif|.GIF|.png|.PNG|.bmp|.BMP)$" ForeColor="Red"></asp:RegularExpressionValidator>
</p>
<p>
    <asp:Button ID="addBtn" runat="server" OnClick="addBtn_Click" Text="Add item" />
</p>
<p>
    <asp:Label ID="errorlist" runat="server" ForeColor="Red"></asp:Label>
</p>
</asp:Content>
