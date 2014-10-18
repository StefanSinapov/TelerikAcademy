<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebRandomGenerator.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Random generator</title>
</head>
<body>
    <form id="formMain" runat="server">
    <div>
        <asp:TextBox runat="server" ID="tbFirstNumber"></asp:TextBox>
        <br/>
        <asp:TextBox runat="server" ID="tbSecondNumber"></asp:TextBox>
        <br/>
        <asp:Button runat="server" Text="Generate" ID="btnGenerateRandom" OnClick="GenerateRandom"/>
        <br/>
        <asp:Label runat="server" ID="lbResult"></asp:Label>
    </div>
    </form>
</body>
</html>
