<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BrowserTypeAndIP.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <div>
            <p>Your browser is:
                <asp:Label runat="server" ID="LabelBrowser"></asp:Label></p>
            <p>Your IP address is:
                <asp:Label runat="server" ID="LabelIpAddress"></asp:Label></p>
            <p>If you are running your server on localhost it will return 127.0.0.1 or just ::1</p>
        </div>
    </form>
</body>
</html>
