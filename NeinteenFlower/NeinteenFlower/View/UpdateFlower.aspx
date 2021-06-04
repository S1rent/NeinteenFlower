<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateFlower.aspx.cs" Inherits="NeinteenFlower.View.UpdateFlower" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>NineteenFlower - Update Flower</title>
</head>
<body>
    <form id="form2" runat="server">
        <asp:Image ID="Picture" width="100px" runat="server" />
        <br /><br />

        <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label3" runat="server" Text="Type: "></asp:Label>
        <asp:TextBox ID="TypeTxt" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label4" runat="server" Text="Description: "></asp:Label>
        <asp:TextBox ID="DescTxt" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label5" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="PriceTxt" runat="server"></asp:TextBox>
        <br /><br />

        <asp:Label ID="Label6" runat="server" Text="New Image: "></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br /><br />

        <asp:Button ID="BtnUpdate" OnClick ="btnUpdate_Click" runat="server" Text="Update Flower" />
        <asp:Button ID="BtnBack" OnClick ="btnBack_Click" runat="server" Text="Back" />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </form>
</body>
</html>