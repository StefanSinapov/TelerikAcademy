<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HTMLEscapingText.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormMain" runat="server">
        <asp:TextBox runat="server" ID="TextBoxInput"></asp:TextBox>
        <br/>
        <br/>
        <asp:Button runat="server" ID="ButtonShowText" OnClick="ButtonShowText_OnClick" Text="Click me"/>
        <br/>
        <br/>
        <strong>TextBox: </strong>
        <asp:TextBox runat="server" ID="TextBoxOutput"></asp:TextBox>
        <br/>
        <strong>Label: </strong>
        <asp:Label runat="server" ID="LabelOutput"></asp:Label>
    </form>
</body>
</html>
