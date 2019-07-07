<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ProjectCIS.About" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <h1 class="text-center" style="font-size: xx-large"><strong>Train! Fight! Succeed!</strong></h1>
    <p>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/GymBanner_2_1.jpg" Width="100%" />
    </p>
<p>
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/£5 off first order in shop (2).png" Width="100%" />
    </p>
    <p>
        <asp:Image ID="Image4" runat="server" Height="414px" ImageUrl="~/Images/WomenOnly.png" Width="100%" />
    </p>
<p>
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/join.png" Width="100%" />
    </p>
    <h1>
        <asp:Label ID="clickLbl" runat="server" Text="Click items below if you are interested"></asp:Label>
    </h1>
    <p>
 
        <asp:ImageButton ID="advertisement" runat="server"  PostBackUrl ="~/menu2.aspx"  Height="25%" Width="25%" />
 
        <asp:ImageButton ID="advertisement0" runat="server"  PostBackUrl ="~/menu2.aspx"  Height="25%" Width="25%" />
 
        <asp:ImageButton ID="advertisement1" runat="server"  PostBackUrl ="~/menu2.aspx" Height="25%" Width="25%" />
 
        <asp:ImageButton ID="advertisement2" runat="server"  PostBackUrl ="~/menu2.aspx"  Height="25%" Width="25%" />
 
        

 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<h1>
 
        <asp:Label ID="gymLbl" runat="server" style="font-weight: 700; font-size: larger" Text="Gym Review"></asp:Label>
    </h1>
    <p>
        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" style="font-size: large" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnRowDataBound ="GridView1_RowDataBound" PageSize="5" Width="100%" DataKeyNames="Expr1"   >
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Customer username" SortExpression="username" />
                <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                <asp:BoundField DataField="rating" HeaderText="rating (1 star lowest - 5 star highest)" SortExpression="rating" />
            </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" SelectCommand="SELECT GymReview.rating, GymReview.comment, GymReview.fkCustomer, customers.username, customers.Id AS Expr1 FROM GymReview INNER JOIN customers ON GymReview.fkCustomer = customers.Id"></asp:SqlDataSource>
    </p>
    <p>
        <strong>
        <asp:Label ID="reviewLbl" runat="server" Text="please help our service if you have any constructive critism please rate us below with what you enjoy about the gym and what we could improve, thank you!"></asp:Label>
        </strong>
</p>
    <p>
        <asp:Label ID="ratingLbl" runat="server" Text="Rating of gym (1 lowest - 5 highest):"></asp:Label>
       
       
        
       
    &nbsp;<asp:DropDownList ID="reviewdrop" runat="server" Width="75px">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
       
       
        
       
    </p>
    <p>
        <asp:Label ID="feedbackLbl" runat="server" Text="Feedback of the gym:"></asp:Label>
        &nbsp;<asp:TextBox ID="FeedbackTxt" runat="server" Height="36px" TextMode="MultiLine" Width="281px"></asp:TextBox>
     
    </p>
    <p>
        <asp:Button ID="submitBtn" runat="server" Text="Submit feedback" OnClick="Button1_Click" />
    </p>
    <p>
        <asp:Label ID="errorlbl" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
    </p>
    </asp:Content>
