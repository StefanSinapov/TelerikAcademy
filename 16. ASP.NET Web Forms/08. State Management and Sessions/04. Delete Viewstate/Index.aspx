<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_04.Delete_Viewstate.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete ViewState</title>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
</head>
<body>
    <form id="FormMain" runat="server">
        <div>
            <asp:TextBox runat="server" ID="TextBoxInput"></asp:TextBox>
            <asp:Button runat="server" ID="ButtonSubmit" Text="Enter" OnClick="ButtonSubmit_OnClick" />
            <button id="delete-view-state">Delete ViewState from form</button>

            <h3>Your entered text (view state)</h3>
            <asp:Label runat="server" ID="LabelOutput"></asp:Label>
        </div>
    </form>
    <script>
        $(document).ready(
            $('#delete-view-state').on('click', function () {

                $("#__VIEWSTATE").val("");
            })
        );
    </script>
</body>
</html>
