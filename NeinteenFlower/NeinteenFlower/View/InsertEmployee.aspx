<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="InsertEmployee.aspx.cs" Inherits="NeinteenFlower.View.InsertEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    NeinteenFlower - Insert Employee
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Text="Insert Employee"></asp:Label><br />

    <asp:Label runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox><br />

    <asp:Label runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox><br />

    <asp:Label runat="server" Text="Name: "></asp:Label>
    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox><br />

    <asp:Label runat="server" Text="Birthdate"></asp:Label>
    <asp:TextBox ID="TextBoxCalendar" runat="server" TextMode="Date"></asp:TextBox><br />

    <asp:Label runat="server" Text="Gender"></asp:Label><br />
    <asp:RadioButton ID="RadioButtonMale" runat="server" Text="Male" GroupName="gender" />
    <asp:RadioButton ID="RadioButtonFemale" runat="server" Text="Female" GroupName="gender" /> <br />  

    <asp:Label runat="server" Text="Phone Number: "></asp:Label>
    <asp:TextBox ID="TextBoxPhoneNumber" runat="server"></asp:TextBox><br />

    <asp:Label runat="server" Text="Address: "></asp:Label>
    <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox><br />

    <asp:Label runat="server" Text="Salary: "></asp:Label>
    <asp:TextBox ID="TextBoxSalary" runat="server" TextMode="Number"></asp:TextBox><br /><br />

    <asp:Label ID="LabelErrorMessage" runat="server" Text="" Visible="true"></asp:Label><br />
    <asp:Button ID="ButtonInsert" runat="server" OnClick="ButtonInsertTapped" Text="Insert" /><br /><br />
</asp:Content>
