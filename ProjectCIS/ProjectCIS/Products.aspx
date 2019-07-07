<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ProjectCIS.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />     

 <table>
        <tr>
            <td rowspan="4">
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage" />
            </td>
            <td style="height: 110px">
                <h2>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
                <hr />
                <asp:Image ID="Image1" runat="server" Width="20%" />
&nbsp;- <span style="font-size: small">Average rating</span><br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription"></asp:Label>
            </td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td>Product No:
                <br />
                <asp:Label ID="lblItemNr" runat="server" Style="font-style: italic"></asp:Label>
                <br />
                <br />
                Stock left:<br />
                <asp:Label ID="stockLbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice"></asp:Label><br />
                Quantity:<asp:DropDownList ID="ddlAmount" runat="server" Width="101px"></asp:DropDownList><br />
                <asp:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_Click" Text="Add Product" />
                <br />
                <asp:Label ID="lblResult" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
    </table>
      <br />
    <p>
        <strong>Review on product&nbsp;&nbsp; &nbsp;</strong></p>
      <p>
          <asp:Label ID="reviewError" runat="server"></asp:Label>
    </p>
      <p>
          <asp:GridView ID="reviewGrid" runat="server"  AutoGenerateColumns="False"  Width="100%" CssClass="Grid" OnRowDataBound="reviewGrid1_RowDataBound" >
             <Columns>
                <asp:BoundField DataField="CName" HeaderText="Customer username" />
                 <asp:BoundField DataField="CText" HeaderText="Review of product" />
                   <asp:BoundField DataField="rating" HeaderText="rating of product (lowest 1 -  5 max)" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="infolbl" runat="server" style="font-weight: 700" Text="If you have purchased this product before please leave a review to help other people on what experience they are expecting"></asp:Label>
      </p>
    <p>
        <asp:Label ID="ratinglbl" runat="server" style="font-weight: 700" Text="Rating of product (lowest 1 - 5 highest):"></asp:Label>
        &nbsp;<asp:DropDownList ID="ratingList" runat="server" Width="62px">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
      </p>
    <p>
        &nbsp;<asp:Label ID="commentlbl" runat="server" style="font-weight: 700" Text="Comment of product:&nbsp;"></asp:Label>
        <asp:TextBox ID="comTxtbx" runat="server" Height="69px" Width="638px" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="reviewBtn" runat="server" OnClick="reviewBtn_Click" Text="submit review" />
    </p>
    <p>
        <asp:Label ID="errorLbl" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
    </p>
</asp:Content>
