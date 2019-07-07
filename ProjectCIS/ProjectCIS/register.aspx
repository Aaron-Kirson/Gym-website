<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ProjectCIS.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <p class="text-center" style="font-size: xx-large; text-align: center">
        <strong>Register Page</strong></p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <strong>Please tell us about yourself</strong></p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <span style="font-size: large"><strong>What is your first name?:
        </strong>
        </span>
        <strong>
        <asp:TextBox ID="fnametbx" runat="server" style="font-size: large" Height="26px"></asp:TextBox>
        </strong>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fnametbx" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <span style="font-size: large"><strong>What is your surname?: </strong>
        </span><strong>
        <asp:TextBox ID="surnametbx" runat="server" style="font-size: large" Height="26px"></asp:TextBox>
        </strong>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="surnametbx" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <span style="font-size: large"><strong>What is your gender?:
        <asp:DropDownList ID="GenderDrop" runat="server" Width="147px">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
        </strong>
        </span>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="GenderDrop" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <span style="font-size: large"><strong>What is your email?: </strong>
        </span>
        <strong>
        <asp:TextBox ID="emailTbx" runat="server"  style="font-size: large" Height="26px" TextMode="Email"></asp:TextBox>
        </strong>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="emailTbx" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <span style="font-size: large"><strong>What is your address?: </strong>
        </span>
        <strong>
        <asp:TextBox ID="addressTxt" runat="server"  style="font-size: large" Height="74px" TextMode="MultiLine" Width="356px"></asp:TextBox>
        </strong>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="addressTxt" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <span style="font-size: large"><strong>What is your post code?:
        <asp:TextBox ID="postTxt" runat="server"  style="font-size: large" Height="26px"></asp:TextBox>
        </strong>
        </span>
        <strong>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="postTxt" ErrorMessage="Type post code in right format e.g (cr0 4nr)" ForeColor="Red" style="font-size: large" ValidationExpression="^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z])))) [0-9][A-Za-z]{2})$"></asp:RegularExpressionValidator>
        </strong></p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <span style="font-size: large"><strong>What would you like your username to be? </strong>
        </span>
        <strong>
        <asp:TextBox ID="usernametbx" runat="server" style="font-size: large" Height="26px"></asp:TextBox>
        </strong>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="usernametbx" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <span style="font-size: large"><strong>What would you like your password to be?</strong></span>
        <strong>
        <asp:TextBox ID="passwordtbx" runat="server"  Font-Size="Medium" Font-Strikeout="False" Height="26px" style="font-size: large" ></asp:TextBox>
        </strong>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="passwordtbx" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <strong>please tell us about your fitness experience</strong></p>
    <p class="text-left" style="font-size: medium; text-align: left">
        <strong>W<span style="font-size: large">hat is your training level: </span>
        <asp:DropDownList ID="LevelDrop" runat="server" DataSourceID="level" DataTextField="experience" DataValueField="experience" style="font-size: large">
        </asp:DropDownList>
        </strong>
        <asp:SqlDataSource ID="level" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" SelectCommand="SELECT [experience] FROM [GymExp]"></asp:SqlDataSource>
    </p>
    <p class="text-left" style="font-size: medium; text-align: left">
        W<strong><span style="font-size: large">hat are your fitness goals:&nbsp; </span>
        <asp:DropDownList ID="goalDrop" runat="server" DataSourceID="SqlDataSource1" DataTextField="goal" DataValueField="goal" style="font-size: large">
        </asp:DropDownList>
        </strong>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" SelectCommand="SELECT * FROM [GymGoal]"></asp:SqlDataSource>
    </p>
    <p class="text-left" style="font-size: medium; text-align: left">
        <strong><span style="font-size: large">How do you usually like to train:</span>
        <asp:DropDownList ID="TrainingDrop" runat="server" DataSourceID="training" DataTextField="Training" DataValueField="Training">
        </asp:DropDownList>
        </strong>
        <asp:SqlDataSource ID="training" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" SelectCommand="SELECT [Training] FROM [GymLevel]"></asp:SqlDataSource>
    </p>
    <p class="text-left" style="font-size: xx-large; text-align: left">
        <strong>Please enter your card details to join/make purchases</strong></p>
    <p class="text-left" style="font-size: large; text-align: left">
        <strong>Please fill in as it appears in your card</strong></p>
    <p class="text-left">
        <strong><span style="font-size: large">Name on card: </span> <asp:TextBox ID="NTxtbx" runat="server" style="font-size: large; " Height="26px"></asp:TextBox>
        </strong>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="NTxtbx" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left">
        <strong><span style="font-size: large">Card number:
        </span>
        <asp:TextBox ID="cardTxtbx" runat="server" style="font-size: large; " Height="27px" TextMode="Number"></asp:TextBox>
        </strong>&nbsp;<strong><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cardTxtbx" ErrorMessage="Please fill in this field to continue" style="font-size: large" ForeColor="Red"></asp:RequiredFieldValidator>
        </strong>
    </p>
    <p class="text-left">
        <strong><span style="font-size: large">Expiry date:&nbsp;&nbsp;<asp:DropDownList ID="eMonthTbx" runat="server" Width="150px">
            <asp:ListItem Value="1">Jan</asp:ListItem>
            <asp:ListItem Value="2">Feb</asp:ListItem>
            <asp:ListItem Value="3">March</asp:ListItem>
            <asp:ListItem Value="4">April</asp:ListItem>
            <asp:ListItem Value="5">May</asp:ListItem>
            <asp:ListItem Value="6">June</asp:ListItem>
            <asp:ListItem Value="7">july</asp:ListItem>
            <asp:ListItem Value="8">August</asp:ListItem>
            <asp:ListItem Value="9">Sept</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">Nov</asp:ListItem>
            <asp:ListItem Value="12">Dec</asp:ListItem>
        </asp:DropDownList>
&nbsp;</span><span style="font-size: large">&nbsp; </span> <asp:TextBox ID="eYearTbx" runat="server" Width="211px" style="font-size: large" TextMode="Number" Height="27px" required>Year e.g (18, 19)</asp:TextBox>
        <span style="font-size: large">&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="eYearTbx" ErrorMessage="please fill year like this with two number e.g (18, 19)" ForeColor="Red" ValidationExpression="^[0-9]{2}$"></asp:RegularExpressionValidator>
    </span></strong>
    </p>
    <p   text-align: left">
        <strong>
        <asp:Button ID="submitbtn" runat="server" OnClick="Button1_Click" Text="Submit information" />
        </strong>
    </p>
    <p class="text-left"  text-align: left">
        <asp:Label ID="errorLbl" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
