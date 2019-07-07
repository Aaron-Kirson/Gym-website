<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="basket.aspx.cs" Inherits="ProjectCIS.basket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">     
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <asp:Panel ID="pnlShoppingCart" runat="server">
      
    </asp:Panel>
        <table>
            <tr>
                <td style="height: 24px">
                    &nbsp;</td>
                <td style="height: 24px">
                    &nbsp;</td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="totalLbl" runat="server" style="font-weight: 700" Text="Total Amount: "></asp:Label>
                </td>
                <td>
                    <asp:Literal ID="litTotalAmount" runat="server" Text="" />
                   
                </td>
            </tr>

            <tr>
                <td style="height: 191px; text-align: left;">
                    <asp:Label ID="EnterDiscountlbl" runat="server" style="font-weight: 700" Text="Enter discount code&nbsp; if you have one:"></asp:Label>
                    <strong>&nbsp;</strong><asp:TextBox ID="discountTxt" runat="server"></asp:TextBox>
&nbsp;<br />
                    <asp:Button ID="discountBtn" runat="server" OnClick="discountBtn_Click" Text="Apply discount" />
                    <br />
                    <asp:Label ID="discountError" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
                    <br />
    <p class="text-left">
        <asp:Label ID="typeSecruitylbl" runat="server" style="font-weight: 700" Text="Please enter your secruity code to pay for your items."></asp:Label>
                    </p>
    <p class="text-left">
        &nbsp;<asp:Label ID="codelbl" runat="server" Text="Secruity Code (3 digits back of card): "></asp:Label>
        <asp:TextBox ID="CWTxtbx" runat="server" OnTextChanged="CWTxtbx_TextChanged" TextMode="Number" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="cvCheck" runat="server" ControlToValidate="CWTxtbx" ErrorMessage="please add only 3 digits (e.g 123) " ForeColor="Red" ValidationExpression="^[0-9]{3}$"></asp:RegularExpressionValidator>
    </p>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/menu2.aspx">Continue Shopping</asp:LinkButton> &nbsp;&nbsp; or                     
                    <asp:Button ID="btnCheckout" runat="server" Text="Check Out" CssClass="button" Width="250px"  OnClick="btnCheckout_Click" />

                    <br />
                    <asp:Label ID="errorLbl" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
                </td>
            </tr>

            <tr>
                <td style="height: 191px">
                    &nbsp;</td>
            </tr>

</table>
</asp:Content>
