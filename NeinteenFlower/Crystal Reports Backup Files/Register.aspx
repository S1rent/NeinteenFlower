<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NeinteenFlower.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NeinteenFlower - Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Register"></asp:Label><br />

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
            <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="LabelErrorMessage" runat="server" Text="" Visible="true"></asp:Label><br />
            <asp:Button ID="ButtonRegister" runat="server" OnClick="ButtonRegisterTapped" Text="Register" /><br /><br />

            <asp:Label runat="server" Text="Already have account? "></asp:Label>
            <span><a href="Login.aspx">Login</a></span>
        </div>
    </form>
</body>
</html>
