<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TicTacToe.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="MainForm" runat="server">
        <button id="top_left" runat="server" onserverclick="TopLeftClick">_</button>
        <button id="top_center" runat="server" onserverclick="TopCenterClick">_</button>
        <button id="top_right" runat="server" onserverclick="TopRightClick">_</button>
        <br />
        <button id="middle_left" runat="server" onserverclick="MiddleLeftClick">_</button>
        <button id="middle_center" runat="server" onserverclick="MiddleCenterClick">_</button>
        <button id="middle_right" runat="server" onserverclick="MiddleRightClick">_</button>
        <br />
        <button id="bottom_left" runat="server" onserverclick="BottomLeftClick">_</button>
        <button id="bottom_center" runat="server" onserverclick="BottomCenterClick">_</button>
        <button id="bottom_right" runat="server" onserverclick="BottomRightClick">_</button>
        <br />
    </form>

    <div runat="server" id="score"></div>
</body>
</html>
