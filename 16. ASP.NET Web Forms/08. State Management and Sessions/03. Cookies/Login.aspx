<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cookies.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server" id="FormMain">
        <nav>
            <a href="Index.aspx">Home</a>
            <a href="Login.aspx">Login</a>
        </nav>

        <div runat="server">
            <asp:TextBox runat="server" ID="TextBoxUsername"></asp:TextBox>
            <asp:Button runat="server" ID="ButtonLogin" Text="Login" OnClick="ButtonLogin_OnClick" />
        </div>
    </form>
</body>
</html>
