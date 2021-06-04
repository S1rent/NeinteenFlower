<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreOrder.aspx.cs" Inherits="NeinteenFlower.View.PreOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NineteenFlower - PreOrder</title>
</head>
<body>
    <h1>PreOrder</h1>
    <form id="form1" runat="server">

        <table style="width:900px" border="1" id="FlowerTable">
            <tr>
                <th>Flower Name</th>
                <th>Flower Type</th>
                <th>Flower Description</th>
                <th>Flower Price</th>
                <th>Flower Image</th>
            </tr>
           <tr>
                <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblType" runat="server" ></asp:Label></td>
                <td><asp:Label ID="lblDesc" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
                <td><asp:Image ID="Image1" runat="server" Width="300px" Height="300px" /></td> 
            </tr>
            </table>
        <br />
        <div>
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
           <asp:TextBox ID="quantityTxt" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button ID="poBtn" runat="server" Text="PreOrder" OnClick="poBtn_Click"/>
        </div>
    </form>
</body>
</html>
