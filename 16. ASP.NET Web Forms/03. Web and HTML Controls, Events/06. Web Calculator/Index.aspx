<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebCalculator.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <title>Calculator</title>
</head>
<body>
    <form id="FormCalculator" runat="server" class="container">
        <div class="row">
            <div class="col-md-3 well">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:TextBox runat="server" ID="TextBoxCalc" Enabled="False" CssClass="col-md-12"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonClear" Text="CE" OnClick="ButtonClearClick" CssClass="btn" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonSqrt" OnClick="ButtonSqrtClick" Text="√" CssClass="btn btn-primary" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonOne" OnClick="ButtonOneClick" CssClass="btn btn-default" Text="1" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonTwo" OnClick="ButtonTwoClick" CssClass="btn btn-default" Text="2" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonThree" OnClick="ButtonThreeClick" CssClass="btn btn-default" Text="3" />
                    </div>
                    <div class="col-sm-2 col-md-offset-2">
                        <asp:Button runat="server" ID="ButtonPlus" OnClick="ButtonPlusClick" CssClass="btn btn-primary btn-lg" Text="+" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonFour" OnClick="ButtonFourClick" CssClass="btn btn-default" Text="4" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonFive" OnClick="ButtonFiveClick" CssClass="btn btn-default" Text="5" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonSix" OnClick="ButtonSixClick" CssClass="btn btn-default" Text="6" />
                    </div>
                    <div class="col-sm-2 col-md-offset-2">
                        <asp:Button runat="server" ID="ButtonMinus" OnClick="ButtonMinusClick" Text="-" CssClass="btn btn-primary btn-lg" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonSeven" OnClick="ButtonSevenClick" Text="7" CssClass="btn btn-default" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonEight" OnClick="ButtonEightClick" Text="8" CssClass="btn btn-default" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonNine" OnClick="ButtonNineClick" Text="9" CssClass="btn btn-default" />
                    </div>
                    <div class="col-sm-2 col-md-offset-2">
                        <asp:Button runat="server" ID="ButtonMultiply" OnClick="ButtonMultiplyClick" Text="X" CssClass="btn btn-primary btn-lg" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonZero" OnClick="ButtonZeroClick" Text="0" CssClass="btn btn-default" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonDot" OnClick="ButtonDotClick" Text="." CssClass="btn btn-default" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button runat="server" ID="ButtonEquals" OnClick="ButtonEqualsClick" Text="=" CssClass="btn btn-success" />
                    </div>
                    <div class="col-sm-2 col-md-offset-2">
                        <asp:Button runat="server" ID="ButtonDivide" OnClick="ButtonDivideClick" Text="/" CssClass="btn btn-primary btn-lg" />
                    </div>

                </div>
            </div>
        </div>
    </form>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
