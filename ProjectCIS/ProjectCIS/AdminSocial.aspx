<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminSocial.aspx.cs" Inherits="ProjectCIS.AdminSocial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <h1>Admin social media page</h1>
    <h3>
        <strong>Please fill in details to post tweet </strong>
    </h3>
    <p>
        <strong>Upload image:</strong>
        <asp:FileUpload ID="uploadimage" runat="server"  accept=".png,.jpg,.jpeg,.gif" />
     <asp:RegularExpressionValidator ID="regexValidator" runat="server"
     ControlToValidate="uploadimage"
     ErrorMessage="Only images can be uploaded!" 
     ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.JPG|.gif|.GIF|.png|.PNG|.bmp|.BMP)$" ForeColor="Red" style="font-weight: 700"></asp:RegularExpressionValidator>
    </p>
    <p>
        <strong>Message body:
        <asp:TextBox ID="tweetTxt" runat="server" Height="104px"  Width="413px" TextMode="MultiLine"></asp:TextBox>
        &nbsp;</strong><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tweetTxt" ErrorMessage="Only allowed 280 characters, remove some words!" ForeColor="Red" style="font-weight: 700" ValidationExpression="[\s\S]{0,280}$"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Button ID="tweetBtn" runat="server" OnClick="tweetBtn_Click" Text="Submit tweet" />
    </p>
    <h3>
        <strong>View twitter account </strong>
    </h3>
    <p>
        <asp:LinkButton ID="TwitterLink" runat="server" href="https://twitter.com/" target="_blank">Go to my Twitter</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="errorlbl" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
    </p>
</asp:Content>
