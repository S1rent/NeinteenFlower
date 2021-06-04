<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NeinteenFlower.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    NeinteenFlower - Home
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:PlaceHolder ID="TablePlaceHolder" runat="server">
        <table style="width:900px" border="1" id="FlowerTable">
            <tr>
                <th>Flower Name</th>
                <th>Flower Type</th>
                <th>Flower Description</th>
                <th>Flower Price</th>
                <th>Flower Image</th>
                <th>Action</th>
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
                            <asp:Button runat="server" Text="Pre Order" CommandArgument='<%# Eval("FlowerID") %>' CommandName="PreOrderFlowerClicked" OnClick="PreOrderFlowerClickHandler" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </asp:PlaceHolder>
</asp:Content>
