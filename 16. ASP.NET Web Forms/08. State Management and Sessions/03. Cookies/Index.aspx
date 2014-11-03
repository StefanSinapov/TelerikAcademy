<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Cookies.Index" %>

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
            <h3>Welcome,
                <asp:Label runat="server" ID="LabelUsername"></asp:Label></h3>
        </div>
    </form>
</body>
</html>
