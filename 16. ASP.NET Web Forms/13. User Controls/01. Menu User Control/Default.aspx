<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MenuUserControl.Default" %>

<%@ Register Src="~/Controls/Menu/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="FormMain" runat="server">
        <uc1:Menu runat="server" id="MenuAside" />
        
        <br/>
        <p>Control with custom font (Times New Roman)</p>
        <uc1:Menu runat="server" id="MenuCustomFont" FontFamily="Times New Roman" />
    </form>
</body>
</html>
