<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebRandomGenerator.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random Generator</title>
</head>
<body>
    <form id="formMain" runat="server">
    <div>
        <input type="number" runat="server" ID="inputFirstNumber"/>
        <br/>
        <input type="number" runat="server" ID="inputSecondNumber"/>
        <br/>
        <button runat="server" ID="btnGenearetRandom" OnServerClick="GenerateRandom">Generate</button>
        <br/>
        <p runat="server" ID="randomResult"></p>
    </div>
    </form>
</body>
</html>
