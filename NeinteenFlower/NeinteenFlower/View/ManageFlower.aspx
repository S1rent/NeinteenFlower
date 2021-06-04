<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFlower.aspx.cs" Inherits="NeinteenFlower.View.ManageFlower" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NineteenFlower - Manage Flower</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="insertFlower" runat="server" NavigateUrl="~/View/InsertFlower.aspx">Insert Flower</asp:HyperLink>
            <br /> <br />
            <asp:Label Text="deleteSuccess" runat="server" ID="lblDel" Visible="false"/>
        </div>

        <table style="width:900px" border="1" id="FlowerTable">
            <tr>
                <th>Flower Name</th>
                <th>Flower Type</th>
                <th>Flower Description</th>
                <th>Flower Price</th>
                <th>Flower Image</th>
                <th colspan="2">Action</th>
            </tr>
    
            <% if (flowerList.Count == 0)
               { %>
               <tr><td colspan="6" style="text-align: center;">No Data.</td></tr>
            <% } %>

            <asp:Repeater ID="FlowerRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("FlowerName") %></td>
                        <td><%# FormatFlowerTypeID(Eval("FlowerTypeID").ToString()) %></td>
                        <td><%# Eval("FlowerDescription") %></td>
                        <td><%# Eval("FlowerPrice") %></td>
                        <td><image src='<%# Eval("FlowerImage") %>'' style="width: 300px; height: 300px;"></image></td>
                        <td>
                            <asp:Button ID="btnUp" runat="server" Text="Update" OnClick="btnUp_Click" CommandArgument='<%# Eval("FlowerID") %>' />
                        </td>
                        <td>
                            <asp:Button ID="btnDel" runat="server" Text="Delete" OnClick="btnDel_Click" CommandArgument='<%# Eval("FlowerID") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
