<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateShop.aspx.cs" Inherits="YoavProject.CreateShop" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
        <script src="JavaScript.js"></script>

<body>
        <form id="form1" runat="server">
            <div>
                <label>Shop Password:</label>
                <asp:TextBox ID="ShopPassword" runat="server"/>
            </div>

            <div>
                <label>TransferOpt:</label>
                <asp:DropDownList ID="TransferOpt" runat="server" >
                    <asp:ListItem Value="Blankets">Blankets</asp:ListItem>
                    <asp:ListItem Value="Rings">Rings</asp:ListItem>
                    <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div>
                <label>Particial:</label>
                <asp:CheckBox ID="Particial" runat="server" />
            </div>
           
<%--         ..<asp:Literal ID="asb" runat="server"></asp:Literal>--%>



            <div>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </form>
    <link href="StyleSheet1.css" rel="stylesheet" />
</body>
</html>
