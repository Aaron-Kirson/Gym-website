<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="control.aspx.cs" Inherits="ProjectCIS.control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
        <p><strong>Press button below to add more products to the shop</strong></p>
        <asp:LinkButton ID="addLink" runat="server" PostBackUrl="~/addProduct.aspx">Add new product </asp:LinkButton>
        <br />
        <br />
        Edit or delete products in the database below.<asp:GridView ID="ProductGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource9" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="image" HeaderText="image" SortExpression="image" />
                <asp:BoundField DataField="stock" HeaderText="stock" SortExpression="stock" />
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
        <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" DeleteCommand="DELETE FROM [Products] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Products] ([name], [price], [Description], [image], [stock]) VALUES (@name, @price, @Description, @image, @stock)" SelectCommand="SELECT * FROM [Products]" UpdateCommand="UPDATE [Products] SET [name] = @name, [price] = @price, [Description] = @Description, [image] = @image, [stock] = @stock WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="stock" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="stock" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
    </asp:SqlDataSource>
    <strong>Edit current membership deals below</strong><p>
        <asp:LinkButton ID="addMembership" runat="server" PostBackUrl="~/addMembership.aspx">Add new membership</asp:LinkButton>
    </p>
    <p>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource8" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
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
        <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" DeleteCommand="DELETE FROM [memberships] WHERE [Id] = @Id" InsertCommand="INSERT INTO [memberships] ([name], [Price]) VALUES (@name, @Price)" SelectCommand="SELECT * FROM [memberships]" UpdateCommand="UPDATE [memberships] SET [name] = @name, [Price] = @Price WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="Price" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="Price" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <strong>Delete any comments that are inappriorate below</strong></p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="CText" HeaderText="CText" SortExpression="CText" />
                <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
                <asp:BoundField DataField="CName" HeaderText="CName" SortExpression="CName" />
                <asp:BoundField DataField="fkProduct" HeaderText="fkProduct" SortExpression="fkProduct" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" DeleteCommand="DELETE FROM [comments] WHERE [Id] = @Id" InsertCommand="INSERT INTO [comments] ([CText], [rating], [CName], [fkProduct]) VALUES (@CText, @rating, @CName, @fkProduct)" SelectCommand="SELECT * FROM [comments]" UpdateCommand="UPDATE [comments] SET [CText] = @CText, [rating] = @rating, [CName] = @CName, [fkProduct] = @fkProduct WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CText" Type="String" />
                <asp:Parameter Name="rating" Type="Int32" />
                <asp:Parameter Name="CName" Type="String" />
                <asp:Parameter Name="fkProduct" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="CText" Type="String" />
                <asp:Parameter Name="rating" Type="Int32" />
                <asp:Parameter Name="CName" Type="String" />
                <asp:Parameter Name="fkProduct" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
<p>
        <strong>Delete any gym reviews which may be inappriorate </strong>
    </p>
<p>
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource3" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
                <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                <asp:BoundField DataField="fkCustomer" HeaderText="fkCustomer" SortExpression="fkCustomer" />
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" DeleteCommand="DELETE FROM [GymReview] WHERE [Id] = @Id" InsertCommand="INSERT INTO [GymReview] ([rating], [comment], [fkCustomer]) VALUES (@rating, @comment, @fkCustomer)" SelectCommand="SELECT * FROM [GymReview]" UpdateCommand="UPDATE [GymReview] SET [rating] = @rating, [comment] = @comment, [fkCustomer] = @fkCustomer WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="rating" Type="Int32" />
                <asp:Parameter Name="comment" Type="String" />
                <asp:Parameter Name="fkCustomer" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="rating" Type="Int32" />
                <asp:Parameter Name="comment" Type="String" />
                <asp:Parameter Name="fkCustomer" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <strong>Edit or delete current customers signed up to the website</strong></p>
    <p>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource6" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                <asp:BoundField DataField="firstName" HeaderText="firstName" SortExpression="firstName" />
                <asp:BoundField DataField="surname" HeaderText="surname" SortExpression="surname" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="goals" HeaderText="goals" SortExpression="goals" />
                <asp:BoundField DataField="exp" HeaderText="exp" SortExpression="exp" />
                <asp:BoundField DataField="training" HeaderText="training" SortExpression="training" />
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
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" DeleteCommand="DELETE FROM [customers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [customers] ([username], [password], [firstName], [surname], [email], [goals], [exp], [training]) VALUES (@username, @password, @firstName, @surname, @email, @goals, @exp, @training)" SelectCommand="SELECT [Id], [username], [password], [firstName], [surname], [email], [goals], [exp], [training] FROM [customers]" UpdateCommand="UPDATE [customers] SET [username] = @username, [password] = @password, [firstName] = @firstName, [surname] = @surname, [email] = @email, [goals] = @goals, [exp] = @exp, [training] = @training WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="firstName" Type="String" />
                <asp:Parameter Name="surname" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="goals" Type="String" />
                <asp:Parameter Name="exp" Type="String" />
                <asp:Parameter Name="training" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="firstName" Type="String" />
                <asp:Parameter Name="surname" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="goals" Type="String" />
                <asp:Parameter Name="exp" Type="String" />
                <asp:Parameter Name="training" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <strong>Control customer memberships in the gyms</strong></p>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="fkCustomer" HeaderText="fkCustomer" SortExpression="fkCustomer" />
                <asp:BoundField DataField="membership" HeaderText="membership" SortExpression="membership" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="startTime" HeaderText="startTime" SortExpression="startTime" />
                <asp:BoundField DataField="endTime" HeaderText="endTime" SortExpression="endTime" />
                <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" DeleteCommand="DELETE FROM [customerMembership] WHERE [Id] = @Id" InsertCommand="INSERT INTO [customerMembership] ([Id], [membership], [price], [startTime], [endTime], [active], [fkCustomer]) VALUES (@Id, @membership, @price, @startTime, @endTime, @active, @fkCustomer)" SelectCommand="SELECT * FROM [customerMembership]" UpdateCommand="UPDATE [customerMembership] SET [membership] = @membership, [price] = @price, [startTime] = @startTime, [endTime] = @endTime, [active] = @active, [fkCustomer] = @fkCustomer WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="membership" Type="String" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="startTime" />
                <asp:Parameter DbType="Date" Name="endTime" />
                <asp:Parameter Name="active" Type="Boolean" />
                <asp:Parameter Name="fkCustomer" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="membership" Type="String" />
                <asp:Parameter Name="price" Type="Int32" />
                <asp:Parameter DbType="Date" Name="startTime" />
                <asp:Parameter DbType="Date" Name="endTime" />
                <asp:Parameter Name="active" Type="Boolean" />
                <asp:Parameter Name="fkCustomer" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
        <p>
            <strong>Control Discounts </strong>
    </p>
        <p>
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource5" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                    <asp:BoundField DataField="code" HeaderText="code" SortExpression="code" />
                    <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
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
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" DeleteCommand="DELETE FROM [discounts] WHERE [Id] = @Id" InsertCommand="INSERT INTO [discounts] ([amount], [code], [active]) VALUES (@amount, @code, @active)" SelectCommand="SELECT * FROM [discounts]" UpdateCommand="UPDATE [discounts] SET [amount] = @amount, [code] = @code, [active] = @active WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="amount" Type="Int32" />
                    <asp:Parameter Name="code" Type="String" />
                    <asp:Parameter Name="active" Type="Boolean" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="amount" Type="Int32" />
                    <asp:Parameter Name="code" Type="String" />
                    <asp:Parameter Name="active" Type="Boolean" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
    </p>
        <p>
            <asp:LinkButton ID="DiscountLink" runat="server" PostBackUrl="~/adminDiscount.aspx">Add discount</asp:LinkButton>
    </p>
    <p>
            <strong>Change Advertisement on Welcome page </strong>
    </p>
    <p>
            <asp:GridView ID="GridView7" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource4" ForeColor="#333333" GridLines="None" PageSize="5">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="goal" HeaderText="goal" SortExpression="goal" />
                    <asp:BoundField DataField="ImageAD1" HeaderText="ImageAD1" SortExpression="ImageAD1" />
                    <asp:BoundField DataField="ImageAD2" HeaderText="ImageAD2" SortExpression="ImageAD2" />
                    <asp:BoundField DataField="ImageAD3" HeaderText="ImageAD3" SortExpression="ImageAD3" />
                    <asp:BoundField DataField="ImageAD4" HeaderText="ImageAD4" SortExpression="ImageAD4" />
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
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString2 %>" DeleteCommand="DELETE FROM [GymGoal] WHERE [Id] = @Id" InsertCommand="INSERT INTO [GymGoal] ([goal], [ImageAD1], [ImageAD2], [ImageAD3], [ImageAD4]) VALUES (@goal, @ImageAD1, @ImageAD2, @ImageAD3, @ImageAD4)" SelectCommand="SELECT * FROM [GymGoal]" UpdateCommand="UPDATE [GymGoal] SET [goal] = @goal, [ImageAD1] = @ImageAD1, [ImageAD2] = @ImageAD2, [ImageAD3] = @ImageAD3, [ImageAD4] = @ImageAD4 WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="goal" Type="String" />
                    <asp:Parameter Name="ImageAD1" Type="String" />
                    <asp:Parameter Name="ImageAD2" Type="String" />
                    <asp:Parameter Name="ImageAD3" Type="String" />
                    <asp:Parameter Name="ImageAD4" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="goal" Type="String" />
                    <asp:Parameter Name="ImageAD1" Type="String" />
                    <asp:Parameter Name="ImageAD2" Type="String" />
                    <asp:Parameter Name="ImageAD3" Type="String" />
                    <asp:Parameter Name="ImageAD4" Type="String" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
    </p>
<p>
        <strong>Send email to gym member </strong>
    </p>
<p>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/AdminEmail.aspx">Send email page</asp:LinkButton>
    &nbsp;</p>
    <p>
        <strong>Manage gym social media </strong>
    </p>
    <p>
        <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/AdminSocial.aspx">my Twitter account</asp:LinkButton>
    </p>
    <p>
        <strong>Add new admin to system</strong></p>
    <p>
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/addAdmin.aspx">add new admin</asp:LinkButton>
    </p>
<p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
