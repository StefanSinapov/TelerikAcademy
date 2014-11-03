<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SessionStorage.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Session storage</title>
</head>
<body>
    <form id="FormMain" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TextBoxInput"></asp:TextBox>
            <asp:Button runat="server" ID="ButtonSubmit" Text="Enter" OnClick="ButtonSubmit_OnClick" />
            
            <h3>Your entered text</h3>
            <asp:Label runat="server" ID="LabelOutput"></asp:Label>
        </div>
    </form>
</body>
</html>
