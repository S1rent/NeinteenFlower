<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NeinteenFlower_FrontEnd.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NeinteenFlower - Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Login"></asp:Label><br />

            <asp:Label runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox><br />

            <asp:Label runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />

            <asp:Label ID="LabelErrorMessage" runat="server" Text="" Visible="true"></asp:Label><br />
            <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLoginTapped" Text="Login" /><br /><br />

            <span><a href="Register.aspx">Register</a></span>
            <span><a href="ForgotPassword.aspx">Forgot Password</a></span>
        </div>
    </form>
</body>
</html>
