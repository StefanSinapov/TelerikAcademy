<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.Web_Forms_Application.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>Hello from the .aspx code</h1>
        <h1 runat="server" ID="headerFromCode"></h1>
    </div>
    
    <div class="row">
        <div class="col-md-10 col-md-offset-1 well">
            Current assembly location: <strong runat="server" ID="spanAssembyLoc"></strong>
        </div>
    </div>

</asp:Content>
