<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="InsertFlower.aspx.cs" Inherits="NeinteenFlower.View.InsertFlower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    NineteenFlower - Insert Flower
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
        </div>
        <br /> <br />
         <div>
            <asp:Label ID="Label2" runat="server" Text="Image: "></asp:Label>
             <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <br /> <br />
         <div>
            <asp:Label ID="Label3" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="DescTxt" runat="server"></asp:TextBox>
        </div>
        <br /> <br />
         <div>
            <asp:Label ID="Label4" runat="server" Text="Flower Type: "></asp:Label>
            <asp:TextBox ID="TypeTxt" runat="server"></asp:TextBox>
        </div>
        <br /> <br />
         <div>
            <asp:Label ID="Label5" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="PriceTxt" runat="server"></asp:TextBox>
        </div>
        <br /> <br />
        <asp:Button ID="BtnInsert" runat="server" Text="Insert Flower" OnClick="BtnInsert_Click" />
        <asp:Label ID="LblMsg" runat="server"></asp:Label>
</asp:Content>
