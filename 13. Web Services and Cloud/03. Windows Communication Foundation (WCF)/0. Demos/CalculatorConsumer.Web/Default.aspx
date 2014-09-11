<%@ Page Language="C#" AutoEventWireup="true" Inherits="Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Calculator Client Web Application</title>
</head>

<body>
    <form id="formCalculatorConsumer" runat="server">
    <div>
        First Number: <asp:TextBox ID="TextBoxFirstNumber" runat="server"/><br />
        <br />
        Second Number: <asp:TextBox ID="TextBoxSecondNumber" runat="server" /><br />
        <br />
        <asp:Button ID="ButtonAdd" runat="server" Text="+" onclick="ButtonAdd_Click" />
        &nbsp;<asp:Button ID="ButtonSubstract" runat="server" Text="-" 
            onclick="ButtonSubstract_Click" />
        &nbsp;<asp:Button ID="ButtonMultiply" runat="server" Text="*" 
            onclick="ButtonMultiply_Click"/>
        &nbsp;<asp:Button ID="ButtonDivide" runat="server" Text="/" 
            onclick="ButtonDivide_Click"/>        
        <br />        
    </div>
    <asp:Label ID="LabelResult" runat="server"></asp:Label>
    </form>
</body>

</html>
