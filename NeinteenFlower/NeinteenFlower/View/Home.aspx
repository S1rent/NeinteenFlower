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

        <% foreach (var flower in flowerList)
            { %>
            <tr>
                <td><% Response.Write(flower.FlowerName); %></td>
                <% if(flower.FlowerTypeID == 1) { %>
                   <td>Daisies</td>
                <% } %>
                <% if(flower.FlowerTypeID == 2) { %>
                   <td>Lilies</td>
                <% } %>
                <% if(flower.FlowerTypeID == 3) { %>
                   <td>Roses</td>
                <% } %>

                <td><% Response.Write(flower.FlowerDescription); %></td>
                <td><% Response.Write(flower.FlowerPrice.ToString()); %></td>
                <td><image src="<% Response.Write(flower.FlowerImage); %>" style="width: 300px; height: 300px;"></image></td>
                <td><asp:Button runat="server" Text="Pre Order" CommandArgument='3' CommandName="PreOrderFlowerClicked" OnClick="PreOrderFlowerClickHandler" /></td>
            </tr>
        <% } %>
        </table>
    </asp:PlaceHolder>
</asp:Content>
