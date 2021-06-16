<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="NeinteenFlower.View.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Forgot Password"></asp:Label><br />

            <asp:Label runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox><br />

            <asp:Label runat="server" ID="LabelCaptchaHelper" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="LabelCaptcha" Text="Captcha: "></asp:Label><br />

            <asp:Label runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />

            <asp:Label ID="LabelErrorMessage" runat="server" Text="" Visible="true"></asp:Label><br />
            <asp:Button ID="ButtonReset" runat="server" OnClick="ButtonResetTapped" Text="Reset Password"/><br /><br />
        </div>
    </form>
</body>
</html>
