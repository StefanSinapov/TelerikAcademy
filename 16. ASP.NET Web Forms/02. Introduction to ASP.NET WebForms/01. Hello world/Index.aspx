<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_01.Hello_world.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello world Web Forms</title>
</head>
<body>
    <form id="indexForm" runat="server">
    <div>
        <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
        <asp:Button runat="server" ID="btnSubmit" OnClick="PrintResult" Text="Submit"/>
        <br/>
        <asp:Label runat="server" ID="lbResult" ></asp:Label>
    </div>
    </form>
</body>
</html>
