<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAlbum.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Album</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="FormMain" runat="server">
        <div>
            <ajaxToolkit:ToolkitScriptManager ID="ScriptManager" runat="server">
            </ajaxToolkit:ToolkitScriptManager>



            <ajaxToolkit:SlideShowExtender ID="SlideShowExtender2" runat="server"
                BehaviorID="SSBehaviorID"
                TargetControlID="Image"
                SlideShowServiceMethod="GetSlides"
                AutoPlay="true"
                ImageDescriptionLabelID="imageDescription"
                NextButtonID="nextButton"
                PreviousButtonID="prevButton"
                PlayButtonID="playButton"
                PlayButtonText="Play"
                StopButtonText="Stop"
                Loop="true">
            </ajaxToolkit:SlideShowExtender>

            <div class="well col-md-6 col-md-offset-3">
                <asp:Image ID="Image" CssClass="img-thumbnail" runat="server"
                    Height="400px" Width="400px" />
                <asp:Label ID="imageTitle" runat="server" Text=""></asp:Label><br />
                <strong>
                    <asp:Label ID="imageDescription" runat="server" Text=""></asp:Label>

                </strong><br />
                <asp:Button ID="prevButton" runat="server" Text="Previous" />
                <asp:Button ID="playButton" runat="server" Text="" />
                <asp:Button ID="nextButton" runat="server" Text="Next" />
            </div>
        </div>
    </form>
</body>
</html>
