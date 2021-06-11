<%@ Page Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="UpdateFlower.aspx.cs" Inherits="NeinteenFlower.View.UpdateFlower" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Neinteen Flower - Update Flower
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Image ID="Picture" width="100px" runat="server" />
    </div>
    <br /><br />

    <div>
        <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
    </div>
    <br /><br />

    <div>
        <asp:Label ID="Label3" runat="server" Text="Type: "></asp:Label>
        <asp:TextBox ID="TypeTxt" runat="server"></asp:TextBox>
    </div>
    <br /><br />

    <div>
        <asp:Label ID="Label4" runat="server" Text="Description: "></asp:Label>
        <asp:TextBox ID="DescTxt" runat="server"></asp:TextBox>
    </div>
    <br /><br />
        
    <div>
        <asp:Label ID="Label5" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="PriceTxt" runat="server"></asp:TextBox>
    </div>
    <br /><br />

    <div>
        <asp:Label ID="Label6" runat="server" Text="New Image: "></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
    <br /><br />

    <asp:Button ID="BtnUpdate" OnClick ="btnUpdate_Click" runat="server" Text="Update Flower" />
    <asp:Button ID="BtnBack" OnClick ="btnBack_Click" runat="server" Text="Back" />
    <br /><br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <br /><br />
</asp:Content>
